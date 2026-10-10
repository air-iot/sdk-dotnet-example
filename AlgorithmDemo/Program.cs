using System;
using System.Text;
using KesiGts.Algorithm;
using KesiGts.Data;
using KesiGts.Tools;
using Newtonsoft.Json.Linq;

namespace AlgorithmDemo
{
    /// <summary>
    /// 最简算法示例：加法（result = a + b）。
    /// 平台调用 Run 时传入 {"function":"add","input":{"a":1,"b":2}}，
    /// 返回 {"result":3}。
    /// </summary>
    class AddAlgorithm : IService
    {
        /// <summary>返回算法配置 Schema（输入 a、b 两个数字）。</summary>
        public CommResult Schema(LogContext ctx, IAlgorithmApp app, string lang)
        {
            return CommResult.Success("ok", new
            {
                input = new
                {
                    a = new { type = "number", title = "加数 a" },
                    b = new { type = "number", title = "加数 b" },
                },
                output = new
                {
                    result = new { type = "number", title = "求和结果" },
                },
            });
        }

        /// <summary>启动算法服务（无资源需要初始化）。</summary>
        public ErrorInfo Start(LogContext ctx, IAlgorithmApp app)
        {
            return null; // null 表示成功
        }

        /// <summary>执行算法：解析 input 中的 a、b，返回 a + b。</summary>
        public CommResult Run(LogContext ctx, IAlgorithmApp app, byte[] data)
        {
            // data 格式: {"function":"add","input":{"a":1,"b":2}}
            var json = JObject.Parse(Encoding.UTF8.GetString(data));
            double a = json["input"]?["a"]?.Value<double>() ?? 0;
            double b = json["input"]?["b"]?.Value<double>() ?? 0;
            Logger.LogInfo(string.Format("加法计算: {0} + {1}", a, b));
            return CommResult.Success("ok", new { result = a + b });
        }

        /// <summary>停止算法服务。</summary>
        public ErrorInfo Stop(LogContext ctx, IAlgorithmApp app)
        {
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C
            new AlgorithmApp(args).Start(new AddAlgorithm());
        }
    }
}

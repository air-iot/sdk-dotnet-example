using System.Text;
using KesiGts.Data;
using KesiGts.FlowExtension;
using KesiGts.Tools;
using Newtonsoft.Json.Linq;

namespace FlowExtensionDemo
{
    /// <summary>
    /// 最简流程扩展示例：把输入中的 value 乘以 2 返回。
    /// 输入示例：{"value":21}，输出：{"result":42}。
    /// </summary>
    class DoubleExtension : IFlowExtension
    {
        /// <summary>返回扩展配置 Schema。</summary>
        public CommResult Schema(LogContext ctx, IFlowExtensionApp app, string locale)
        {
            return CommResult.Success("ok", new
            {
                input = new { value = new { type = "number", title = "输入值" } },
                output = new { result = new { type = "number", title = "翻倍结果" } },
            });
        }

        /// <summary>执行扩展：result = value * 2。</summary>
        public CommResult Run(LogContext ctx, IFlowExtensionApp app, byte[] input)
        {
            var json = input == null
                ? new JObject()
                : JObject.Parse(Encoding.UTF8.GetString(input));

            double value = json["value"]?.Value<double>() ?? 0;
            return CommResult.Success("ok", new { result = value * 2 });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C
            new FlowExtensionApp(args).Start(new DoubleExtension());
        }
    }
}

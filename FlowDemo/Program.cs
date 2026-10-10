using System;
using System.Text;
using KesiGts.Data;
using KesiGts.Flow;
using KesiGts.Tools;
using Newtonsoft.Json.Linq;

namespace FlowDemo
{
    /// <summary>
    /// 最简流程节点示例：把节点配置中的 message 原样返回（echo）。
    /// 节点配置示例：{"message":"hello flow"}，执行结果返回同一 message。
    /// </summary>
    class EchoFlow : IFlow
    {
        /// <summary>执行流程节点：读取 config.message 并原样返回。</summary>
        public CommResult Handler(LogContext ctx, IFlowApp app, Request req)
        {
            // req.Config 为节点配置 JSON 字节
            var config = req.Config == null
                ? new JObject()
                : JObject.Parse(Encoding.UTF8.GetString(req.Config));

            string message = config["message"]?.ToString() ?? "";
            Logger.LogInfo("流程节点执行, message=" + message);
            return CommResult.Success("ok", new { message });
        }

        /// <summary>调试流程节点：返回调试日志与输出值。</summary>
        public CommResult Debug(LogContext ctx, IFlowApp app, DebugRequest req)
        {
            var config = req.Config == null
                ? new JObject()
                : JObject.Parse(Encoding.UTF8.GetString(req.Config));

            var result = new DebugResult();
            result.Logs.Add(new Syslog
            {
                Level = "info",
                Time = DateTime.Now.ToString("o"),
                Msg = "echo 节点调试执行",
            });
            result.Value["message"] = config["message"]?.ToString() ?? "";
            return CommResult.Success("ok", result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C
            new FlowApp(args).Start(new EchoFlow());
        }
    }
}

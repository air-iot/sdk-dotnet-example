using System.Collections.Generic;
using System.Text;
using KesiGts.Data;
using KesiGts.DataRelay;
using KesiGts.Tools;
using Newtonsoft.Json.Linq;

namespace DataRelayDemo
{
    /// <summary>
    /// 最简数据中转示例：HttpProxy 收到请求后返回 {"echo": 请求体原文}。
    /// </summary>
    class EchoRelay : IDataRelay
    {
        /// <summary>启动服务（无资源需要初始化）。</summary>
        public ErrorInfo Start(LogContext ctx, IDataRelayApp app, byte[] config)
        {
            return null; // null 表示成功
        }

        /// <summary>代理接口：原样回显请求体。</summary>
        public CommResult HttpProxy(LogContext ctx, IDataRelayApp app, string t,
            Dictionary<string, List<string>> header, byte[] data)
        {
            string body = data == null ? "" : Encoding.UTF8.GetString(data);
            Logger.LogInfo("收到代理请求, type=" + t + ", body=" + body);
            return CommResult.Success("ok", new { echo = body });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C
            new DataRelayApp(args).Start(new EchoRelay());
        }
    }
}

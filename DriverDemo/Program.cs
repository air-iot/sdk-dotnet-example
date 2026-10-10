using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Gts.Driver.Grpc;
using KesiGts.Data;
using KesiGts.Driver;
using KesiGts.Driver.Http;
using KesiGts.Tools;

namespace DriverDemo
{
    /// <summary>
    /// 模拟温度采集驱动：启动后每 5 秒上报一个随机温度点。
    /// 需要本机有 MQTT broker（config.yaml 中 mq.mqtt 地址）才能启动成功。
    /// </summary>
    class SimDriver : IDriver
    {
        private IDriverApp _app;
        private Timer _timer;
        private readonly Random _rnd = new Random();

        /// <summary>返回驱动配置 Schema（供平台动态生成配置界面）。</summary>
        public CommResult Schema(LogContext ctx, IDriverApp app, string locale)
        {
            return CommResult.Success("ok", new { });
        }

        /// <summary>启动采集：每 5 秒上报一次随机温度。</summary>
        public ErrorInfo Start(LogContext ctx, IDriverApp app, byte[] config)
        {
            _app = app;
            _timer = new Timer(_ => Report(), null, 0, 5000);
            return null; // null 表示成功
        }

        private void Report()
        {
            double temp = Math.Round(20 + _rnd.NextDouble() * 10, 2);
            var point = new Point
            {
                Table = "demo",
                Id = "device001",
                Fields = new List<Field>
                {
                    new Field { Tag = new Tag { Id = "temperature" }, Value = temp },
                },
                UnixTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            };
            ErrorInfo err = _app.WritePoints(point); // 上报数据点
            if (err != null)
                _app.LogError("demo", "device001", "上报失败: " + err.Message);
        }

        /// <summary>注册自定义 HTTP 路由（本示例不注册）。</summary>
        public void RegisterRoutes(IRouterGroup router)
        {
        }

        /// <summary>执行平台下发的单条控制指令。</summary>
        public CommResult Run(LogContext ctx, IDriverApp app, Command cmd)
        {
            string payload = cmd.Payload == null ? "" : Encoding.UTF8.GetString(cmd.Payload);
            app.LogInfo(cmd.Table, cmd.Id, "收到指令: " + payload);
            return CommResult.Success("success");
        }

        /// <summary>批量执行控制指令。</summary>
        public CommResult BatchRun(LogContext ctx, IDriverApp app, BatchCommand cmd)
        {
            return CommResult.Success("success");
        }

        /// <summary>写数据点。</summary>
        public CommResult WriteTag(LogContext ctx, IDriverApp app, Command cmd)
        {
            return CommResult.Success("success");
        }

        /// <summary>调试驱动。</summary>
        public CommResult Debug(LogContext ctx, IDriverApp app, byte[] config)
        {
            return CommResult.Success("ok");
        }

        /// <summary>驱动自定义 HTTP 代理（本示例不支持）。</summary>
        public CommResult HttpProxy(LogContext ctx, IDriverApp app, string type,
            Dictionary<string, string[]> header, byte[] data)
        {
            return CommResult.Failure("不支持");
        }

        /// <summary>平台侧配置更新回调。</summary>
        public ErrorInfo ConfigUpdate(LogContext ctx, IDriverApp app, ConfigUpdateRequest data)
        {
            return null;
        }

        /// <summary>停止采集，释放资源。</summary>
        public ErrorInfo Stop(LogContext ctx, IDriverApp app)
        {
            _timer?.Dispose();
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C；退出前自动回调 Stop
            new DriverApp(args).Start(new SimDriver());
        }
    }
}

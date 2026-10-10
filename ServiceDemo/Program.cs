using KesiGts.Data;
using KesiGts.Service;

namespace ServiceDemo
{
    /// <summary>
    /// 最简任务服务示例：启动一个 HTTP 服务，访问 /hello 返回 "hello"。
    /// 启动后请求：curl http://127.0.0.1:8080/hello
    /// </summary>
    class HelloService : IService
    {
        /// <summary>启动服务：注册 /hello 路由。</summary>
        public ErrorInfo Start(IServiceApp app)
        {
            app.GetHttpServer().GET("/hello", ctx => ctx.String(200, "hello"));
            return null; // null 表示成功
        }

        /// <summary>停止服务（无资源需要释放）。</summary>
        public ErrorInfo Stop(IServiceApp app)
        {
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C
            new ServiceApp(args).Start(new HelloService());
        }
    }
}

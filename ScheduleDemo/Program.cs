using KesiGts.Data;
using KesiGts.Schedule;
using KesiGts.Tools;

namespace ScheduleDemo
{
    /// <summary>
    /// 最简任务调度示例：每 5 秒执行一次，打印当前时间。
    /// cron 表达式为 6 段（含秒），对齐 robfig cron。
    /// </summary>
    class TickTask : ITask
    {
        /// <summary>启动任务：注册每 5 秒一次的 cron 任务。</summary>
        public ErrorInfo Start(ITaskApp app)
        {
            app.GetCron().Add("*/5 * * * * *", () =>
            {
                Logger.LogInfo("定时任务执行, time=" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            });
            return null; // null 表示成功
        }

        /// <summary>停止任务（无资源需要释放）。</summary>
        public ErrorInfo Stop(ITaskApp app)
        {
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 加载 ./etc/config.yaml 并启动，阻塞直到 Ctrl+C
            new TaskApp(args).Start(new TickTask());
        }
    }
}

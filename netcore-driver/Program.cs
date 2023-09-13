using AiriotSDK.Tools;
using System;
using System.Threading;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            try
            {
                AiriotSDK.Driver.DriverApp app = new(args);
                app.Start(new TestDriver());
                while (true)
                {
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
                Thread.Sleep(5000);
                goto start;
            }
        }
    }
}

using AiriotSDK.Flow;
using AiriotSDK.Tools;
using System;
using System.Threading;

namespace netcore_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FlowApp app = new();
                app.Start(new TestFlow());
                while (true)
                {
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}

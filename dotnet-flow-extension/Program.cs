using AiriotSDK.Tools;
using System;
using System.Threading;

namespace dotnet_flow_extension
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            try
            {
                AiriotSDK.FlowExtension.FlowExtensionApp app = new();
                app.Start(new TestFlow());
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

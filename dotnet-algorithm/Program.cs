using AiriotSDK.Algorithm;
using System;
using System.Threading;

namespace dotnet_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgorithmApp app = new();
            app.Start(new TestAlgorithm());
            while (true)
            {
                Thread.Sleep(5 * 1000);
            }
        }
    }
}

using AiriotSDK.Api;
using AiriotSDK.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace dotnet_api_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.SetLevel("info");
            Config cfg = new()
            {
                ProjectId = "63e5aef4c3879495dfe8b63c",
                Schema = "http",
                Host = "121.89.244.23",
                Port = 31000,
                Credentials = new()
                {
                    AK = "8e81c98d-e63a-76ef-f6c4-6299588989d9",
                    SK = "b9215d93-89d4-e72e-32d8-f804f6c92ff5"
                }
            };

            Client cli = new(cfg);
            Query qr = new()
            {
                Filter = new Dictionary<string, object>
                {
                    { "title", "CoAP" },
                },
                Project = new Dictionary<string, object>
                {
                    { "id",1},
                    { "title",1 }
                }
            };

            string query = JsonConvert.SerializeObject(qr);

            string str = cli.FindTableQuery(query);

            Console.WriteLine(str);
        }
    }
}

using AiriotSDK.Data;
using AiriotSDK.FlowExtension;
using AiriotSDK.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_flow_extension
{
    class TestFlow : IFlowExtension
    {
        public CommResult Run(IFlowExtensionApp app, byte[] input)
        {
            string param = Encoding.UTF8.GetString(input);
            Logger.LogInfo($"执行Run,input:{param}");
            Input i = JsonConvert.DeserializeObject<Input>(param);
            int sum = i.Num1 + i.Num2;
            return CommResult.Success(null, new Dictionary<string, int>() 
            {
                { "sum", sum },
            });
        }

        public CommResult Schema(IFlowExtensionApp app)
        {
            Logger.LogInfo("查询Schema");
            return CommResult.Success(null, Entity.schema);
        }
    }

    class Input
    {
        [JsonProperty("num1")]
        public int Num1 { get; set; }

        [JsonProperty("num2")]
        public int Num2 { get; set; }
    }
}

using AiriotSDK.Data;
using AiriotSDK.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore_flow
{
    class TestFlow : IFlow
    {
        public CommResult Handler(IFlowApp app, Request req)
        {
            return CommResult.Success(null, new Dictionary<string, object>()
                {
                    { "a", 1 },
                }
            );
        }
    }
}

using AiriotSDK.Data;
using AiriotSDK.Flow;
using AiriotSDK.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore_flow
{
    class TestFlow : IFlow
    {
        public CommResult Handler(LogContext ctx, IFlowApp app, Request req)
        {
            Logger.InfoContext(ctx, "Handler");
            return CommResult.Success(null, new Dictionary<string, object>()
                {
                    { "a", 1 },
                }
            );
        }
    }
}

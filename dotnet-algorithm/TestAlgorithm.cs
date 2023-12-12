using AiriotSDK.Algorithm;
using AiriotSDK.Data;
using AiriotSDK.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_algorithm
{
    class TestAlgorithm : IService
    {
        public CommResult Run(LogContext ctx, IAlgorithmApp app, byte[] bytes)
        {
            if (bytes == null)
            {
                return CommResult.Failure("参数无效");
            }

            RunConfig runConfig = JsonConvert.DeserializeObject<RunConfig>(Encoding.UTF8.GetString(bytes));
            if (runConfig == null)
            {
                return CommResult.Failure("反序列化失败");
            }

            switch (runConfig.Function)
            {
                case "add":
                    {
                        if (runConfig.Input == null)
                        {
                            return CommResult.Failure("input为空");
                        }
                        double num1, num2;

                        if (runConfig.Input.ContainsKey("num1") && runConfig.Input["num1"] is double v1)
                        {
                            num1 = v1;
                        } 
                        else
                        {
                            return CommResult.Failure("未找到num1或num1类型错误");
                        }

                        if (runConfig.Input.ContainsKey("num2") && runConfig.Input["num2"] is double v2)
                        {
                            num2 = v2;
                        }
                        else
                        {
                            return CommResult.Failure("未找到num2或num2类型错误");
                        }

                        return CommResult.Success("", num1 + num2);
                    }
                case "abs":
                    {
                        if (runConfig.Input == null)
                        {
                            return CommResult.Failure("input为空");
                        }
                        double num1;

                        if (runConfig.Input.ContainsKey("num1") && runConfig.Input["num1"] is double v)
                        {
                            num1 = v;
                        }
                        else
                        {
                            return CommResult.Failure("未找到num1或num1类型错误");
                        }

                        return CommResult.Success("", Math.Abs(num1));
                    }

                default:
                    return CommResult.Failure("未知的算法类型");
            }
        }

        public CommResult Schema(LogContext ctx, IAlgorithmApp app)
        {
            Logger.InfoContext(ctx, "schema");
            return CommResult.Success(null, Entity.Schema);
        }
    }
}

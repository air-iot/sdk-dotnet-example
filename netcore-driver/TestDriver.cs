using Newtonsoft.Json;
using AiriotSDK.Data;
using AiriotSDK.Driver;
using AiriotSDK.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Examples
{
    public class TestDriver : IDriver
    {
        class StartParam
        {
            public DriverApp app;
            public byte[] bytes;
        }


        bool threadExit = false;
        private async void StartProc(object param)
        {
            if (!(param is StartParam))
            {
                Logger.LogError("参数错误");
                return;
            }
            if (!(param is StartParam obj) || obj.app == null)
            {
                Logger.LogError("参数param转换错误");
                return;
            }

            string models = Encoding.UTF8.GetString(obj.bytes);
            Logger.LogDebug($"start {models}");

            Models.Config config;
            try
            {
                config = JsonConvert.DeserializeObject<Models.Config>(models);
            }
            catch (Exception ex)
            {
                Logger.LogError($"反序列化错误:{ex.Message}");
                return;
            }

            if (config == null || config.Tables == null || config.Tables.Length == 0)
                return;

            while (true && !threadExit)
            {
                foreach (var t in config.Tables)
                { 
                    foreach (var d in t.Devices)
                    {
                        Random random = new Random();
                        List<Field> fields = new List<Field>();

                        if (d.DeviceConfig == null) { continue; }
                        
                        if (d.DeviceConfig.Tags != null && d.DeviceConfig.Tags.Length > 0)
                        {
                            foreach (var t1 in d.DeviceConfig.Tags)
                            {
                                fields.Add(new Field()
                                {
                                    tag = t1,
                                    value = preValue
                                });
                            }
                        }
                        else if (t.Device?.Tags != null && t.Device?.Tags.Length > 0)
                        {
                            foreach (var t1 in t.Device.Tags)
                            {
                                fields.Add(new Field()
                                {
                                    tag = t1,
                                    value = preValue
                                });
                            }
                        }

                        Point point = new Point()
                        {
                            table = t.ID,
                            id = d.ID,
                            fields = fields.ToArray(),
                            time = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
                        };
                        CommResult result = await obj.app.WritePoints(point);
                        if (result.Error != null)
                            Logger.LogError($"数据写入错误,{result.Error.Message}");
                    }
                }
                GetNextValue();
                Thread.Sleep(5000);
            }

        }

        public ErrorInfo Start(IDriverApp app, byte[] bytes)
        {
            StartParam param = new StartParam()
            {
                app = app as DriverApp,
                bytes = bytes,
            };
            Thread thread = new Thread(new ParameterizedThreadStart(StartProc))
            {
                IsBackground = true
            };
            thread.Start(param);
            return null;
        }

        public ErrorInfo Stop(IDriverApp app)
        {
            threadExit = true;
            Logger.LogDebug("stop");
            return null;
        }

        public CommResult Debug(IDriverApp app, byte[] bytes)
        {
            Logger.LogDebug("Debug");
            return null;
        }

        public ErrorInfo Reload(IDriverApp app, byte[] bytes)
        {
            Logger.LogDebug("Reload");
            this.Stop(app);
            Thread.Sleep(10000);
            return this.Start(app, bytes);
        }

        public CommResult Run(IDriverApp app, Command cmd)
        {
            Logger.LogDebug("Run");
            return null;
        }

        public CommResult Schema(IDriverApp app)
        {
            Logger.LogDebug("Schema");
            string schemaPath = AppDomain.CurrentDomain.BaseDirectory + "/etc/schema.js";
            string str = File.ReadAllText(schemaPath);
            return CommResult.Success("", str);
        }

        public CommResult BatchRun(IDriverApp app, BatchCommand cmd)
        {
            throw new NotImplementedException();
        }

        public CommResult WriteTag(IDriverApp app, AiriotSDK.Driver.Command cmd)
        {
            throw new NotImplementedException();
        }

        private double preValue = 0;
        private double GetNextValue()
        {
            preValue += 2;
            if (preValue > 20)
            {
                preValue = 0;
            }
            return preValue;
        }
    }
}

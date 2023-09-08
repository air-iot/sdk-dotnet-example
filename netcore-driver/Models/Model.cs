using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
//using AiriotSDK.Driver;
using Newtonsoft.Json;

namespace Examples.Models
{
    public class Config
    {
        [JsonProperty("id")] public string ID;   // id，唯一标识
        [JsonProperty("name")] public string Name; // 
        [JsonProperty("driverType")] public string DriverType; // 
        [JsonProperty("device")] public DeviceConfig Device; // 模型驱动信息
        [JsonProperty("tables")] public Table[] Tables;// 所属模型的资产配置信息 
    }

    public class Table
    {
        [JsonProperty("id")] public string ID;   // id，唯一标识
        [JsonProperty("project")] public string Project; // 
        [JsonProperty("device")] public DeviceConfig Device; // 模型驱动信息
        [JsonProperty("devices")] public Device[] Devices;// 所属模型的资产配置信息 
    }

    public class Device
    {
        [JsonProperty("id")] public string ID; // 资产id，资产唯一标识
        [JsonProperty("table")] public string Table;
        [JsonProperty("device")] public DeviceConfig DeviceConfig; // 资产驱动信息
    }

    public class DeviceConfig
    {
        [JsonProperty("tags")] public Tag[] Tags; // 驱动数据点
        [JsonProperty("commands")] public Command[] Commands;// 指令配置
        [JsonProperty("setting")] public Settings Settings;
    }

    public class TestCommand
    {
        [JsonProperty("nodeId")] public string NodeId { get; set; }
        [JsonProperty("command")] public Dictionary<string, object> Command { get; set; }
    }

    public class Settings  
    {
        [JsonProperty("interval")] public float Interval;     // 采集周期*秒
    }

    public class Tag
    {
        [JsonProperty("id")] public string ID;
        [JsonProperty("name")] public string Name;

        [JsonProperty("single")] public bool Single;
        [JsonProperty("value")] public object Value;
        [JsonProperty("params")] public object Params;
        private byte[] valueBytes;

        [JsonProperty("offset")] public int Offset;
        [JsonProperty("area")] public int Area;
        [JsonProperty("dataType")] public string DataType;
        [JsonProperty("length")] public int Length;
        [JsonProperty("index")] public int Index;

        [JsonProperty("tagValue")] public object TagValue;
        [JsonProperty("fixed")] public int Fixed;
        [JsonProperty("mod")] public double Mod;
        [JsonProperty("range")] public object Range;
    }

    public class Command
    {
        [JsonProperty("id")] public string ID;
        [JsonProperty("name")] public string Name;
        [JsonProperty("params")] public object Params;
        [JsonProperty("ops")] public Op[] Ops;
    }

    public class Op
    {
        [JsonProperty("index")] public int Index;
        [JsonProperty("offset")] public int Offset;
        [JsonProperty("area")] public int Area;
        [JsonProperty("dataType")] public string DataType;
        [JsonProperty("single")] public bool Single;
        [JsonProperty("param")] public object Param;
        [JsonProperty("value")] public object Value;
        [JsonProperty("length")] public int Length;
        private byte[] valueBytes;
    }
}

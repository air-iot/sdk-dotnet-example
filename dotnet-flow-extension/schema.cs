using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_flow_extension
{
    class Entity
    {
        public static readonly string schema = "{\"type\":\"object\",\"properties\":{\"num1\":{\"title\":\"参数1\",\"type\":\"number\"},\"num2\":{\"title\":\"参数2\",\"type\":\"number\"}},\"required\":[\"num1\",\"num2\"]}";
    }
}

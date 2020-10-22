using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RdxDevice.Message
{
    public class DeviceMessage 
    {
        public double Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}

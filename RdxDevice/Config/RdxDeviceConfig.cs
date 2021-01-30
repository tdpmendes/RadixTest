using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxDevice.Config
{
    public class RdxDeviceConfig
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string DeviceName { get; set; }
        public string MinValToSend { get; set; }
        public string MaxValToSend { get; set; }
    }
}

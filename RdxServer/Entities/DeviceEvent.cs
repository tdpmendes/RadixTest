using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Entities
{

    public class DeviceEvent : EntityBase
    {
        public DateTime UnixTimestamp { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string DeviceName { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public int Status {get;set;}

    }
}

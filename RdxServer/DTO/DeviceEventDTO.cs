using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.DTO
{
    public class DeviceEventDTO : DataTransferObject
    {
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}

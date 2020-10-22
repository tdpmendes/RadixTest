using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RdxServer.Business.Helpers;

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

        public static DeviceEvent CreateFromDTOParameters(long timestamp, string tag, string value, string valueType)
        {
            DateTime date = DateTimeHelper.FromUnixTimeStamp(timestamp);
            string[] fields = tag.Split('.');
            DeviceEvent dvcEvt = new DeviceEvent();
            dvcEvt.UnixTimestamp = date;
            dvcEvt.Country = fields[0];
            dvcEvt.Region = fields[1];
            dvcEvt.DeviceName = fields[2];
            dvcEvt.Value = value;
            dvcEvt.ValueType = valueType;
            dvcEvt.Status = string.IsNullOrWhiteSpace(dvcEvt.Value) ? 1 : 0;

            return dvcEvt;
        }

    }
}

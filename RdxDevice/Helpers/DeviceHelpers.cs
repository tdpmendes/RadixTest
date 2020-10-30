using RdxDevice.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxDevice.Helpers
{
    public class DeviceHelpers
    {
        public static DateTime FromUnixTimeStamp(long unixTime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return sTime.AddMilliseconds(unixTime);
        }

        public static long ToUnixTimeStamp(DateTime date)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(date - sTime).TotalMilliseconds;
        }

        public static string TagFromConfig(RdxDeviceConfig config)
        {
            return string.Concat(config.Country, ".", config.Region, ".", config.DeviceName);
        }
    }
}

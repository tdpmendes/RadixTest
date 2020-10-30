using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Business.Helpers
{
    public static class DateTimeHelper
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

    }
}

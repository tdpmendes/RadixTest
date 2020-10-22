using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Business.Enums
{
    public enum DeviceEventBusinessStatusResponse
    {
        [Description("success")]
        SUCCESS = 0,
        
        ERROR = 1,
    }
}

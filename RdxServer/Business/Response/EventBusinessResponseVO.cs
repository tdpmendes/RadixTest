using RdxServer.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Business.Response
{
    public class EventBusinessResponseVO
    {
        private DeviceEventBusinessStatusResponse Status { get; } 
        public string ShortMessage { get; }
        public string Message { get; }
        public ResponsePayloadBase Payload { get; }

        public EventBusinessResponseVO(string shortMessage, string message , DeviceEventBusinessStatusResponse status, ResponsePayloadBase payload)
        {
            ShortMessage = shortMessage;
            Status = status;
            Message = message;
            Payload = payload;
        }
    }
}

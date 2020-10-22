using RdxServer.Business.Response;
using RdxServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Business.Interfaces
{
    public interface IEventBusiness
    {
        Task<EventBusinessResponseVO> ProcessEvent(DeviceEventDTO dvcEvt);
    }
}

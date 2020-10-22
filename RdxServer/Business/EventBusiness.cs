using RdxServer.Business.Enums;
using RdxServer.Business.Extensions;
using RdxServer.Business.Interfaces;
using RdxServer.Business.Response;
using RdxServer.DTO;
using RdxServer.Entities;
using RdxServer.Repositories.Interfaces;
using RdxServer.Validators.Interfaces;
using RdxServer.Validators.VO;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Business
{
    public class EventBusiness : IEventBusiness
    {
        private IValidatable<DeviceEventDTO> _validator;
        private IDeviceEventRepository _dvcEvtRepository;

        public EventBusiness(IValidatable<DeviceEventDTO> validator, IDeviceEventRepository dvcEvtRepository)
        {
            _validator = validator;
            _dvcEvtRepository = dvcEvtRepository;
        }

        public async Task<EventBusinessResponseVO> ProcessEvent(DeviceEventDTO dvcEvtDTO)
        {
            int value;
            string valueType = string.Empty; 
            int.TryParse(dvcEvtDTO.Valor, out value);            
            if (value != 0)
            {
                valueType = "INT";
            }
            else
            {
                valueType = "STR";
            }

            ValidationResultList validatonResultList = _validator.Validate(dvcEvtDTO);

            //Seria mais elegante ter feito por filters, mas fiz assim para deixar explicito o processo
            if (validatonResultList.items.Count > 0)
            {
                return new EventBusinessResponseVO("error",
                                                   "The request provided contain errors",
                                                   DeviceEventBusinessStatusResponse.ERROR,
                                                   validatonResultList);
            }

            DeviceEvent dvcEvt = DeviceEvent.CreateFromDTOParameters(dvcEvtDTO.Timestamp, dvcEvtDTO.Tag, dvcEvtDTO.Valor, valueType);
            await _dvcEvtRepository.Add(dvcEvt);

            return new EventBusinessResponseVO("success",
                                               "The request was processed successfully",
                                               DeviceEventBusinessStatusResponse.SUCCESS,
                                               validatonResultList);

        }
    }
}

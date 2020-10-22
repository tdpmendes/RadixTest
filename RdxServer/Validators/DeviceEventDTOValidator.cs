using Microsoft.AspNetCore.Mvc.Rendering;
using RdxServer.DTO;
using RdxServer.Validators.Interfaces;
using RdxServer.Validators.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Validators
{
    public class DeviceEventDTOValidator : IValidatable<DeviceEventDTO>
    {
        public ValidationResultList Validate(DeviceEventDTO dvcEvtDTO)
        {
            ValidationResultList error = new ValidationResultList();
            if (dvcEvtDTO.Timestamp <= 0)
            {
                error.items.Add(new ValidationResult(false, "Invalid value provided for Timestamp"));
            }

            if (string.IsNullOrWhiteSpace(dvcEvtDTO.Tag))
            {
                error.items.Add(new ValidationResult(false, "Tag cannot be empty"));
            }
            else if (dvcEvtDTO.Tag.Length  < 0 && dvcEvtDTO.Tag.Length > 250)
            {
                error.items.Add(new ValidationResult(false, "Tag must be between 0 and 250 characters in size"));
            }

            return error;
        }
    }
}

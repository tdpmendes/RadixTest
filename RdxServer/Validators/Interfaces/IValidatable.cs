using RdxServer.DTO;
using RdxServer.Validators.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Validators.Interfaces
{
    public interface IValidatable<T> where T : DataTransferObject
    {
        ValidationResultList Validate(T dvcEvtDTO);
    }
}

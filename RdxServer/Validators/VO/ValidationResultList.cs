using RdxServer.Business.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Validators.VO
{
    public class ValidationResultList : ResponsePayloadBase
    {
        public IList<ValidationResult> items { get; set; } = new List<ValidationResult>();


    }
}

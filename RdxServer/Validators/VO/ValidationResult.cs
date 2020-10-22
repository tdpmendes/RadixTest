﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Validators.VO
{
    public class ValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }
        public ValidationResult(bool isValid, string error)
        {
            IsValid = isValid;
            ErrorMessage = error;
        }
    }
}

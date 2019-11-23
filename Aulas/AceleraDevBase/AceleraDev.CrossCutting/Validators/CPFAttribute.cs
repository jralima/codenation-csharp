using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AceleraDev.CrossCutting.Validators
{
    public class CPFAttribute : ValidationAttribute
    {
        public CPFAttribute(string errorMessage = "O campo CPF é inválido.") : base(errorMessage)
        {
            
        }

        public override bool IsValid(object value)
        {
            if (value == default) return false;

            return Utils.Utils.ValidaCPF(value.ToString());
        }
    }
}

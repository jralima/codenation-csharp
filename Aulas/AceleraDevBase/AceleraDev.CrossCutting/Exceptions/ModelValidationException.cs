using System;
using System.Collections.Generic;
using System.Text;

namespace AceleraDev.CrossCutting.Exceptions
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message)
            : base(message)
        {
        }

        public ModelValidationException(List<string> messages)
            : base(string.Join("|", messages))
        {
        }

    }
}

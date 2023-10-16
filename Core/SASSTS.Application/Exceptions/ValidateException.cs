using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Exceptions
{
    public class ValidateException : Exception
    {
        public List<string> ErrorMessages { get; set; }

        public ValidateException(ValidationResult result) : base()
        {
            ErrorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationErrors)
        {
            ValidationErrors = new List<string>();
            foreach (var validationError in ValidationErrors)
            {
                ValidationErrors.Add(validationError);
            }
        }
    }
}

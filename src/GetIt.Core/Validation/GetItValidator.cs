using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Core.Validation
{
    public class GetItValidator<T>:AbstractValidator<T> where T : class
    {
        public const string NotNullMessage = "Field can not be empty";
    }
}

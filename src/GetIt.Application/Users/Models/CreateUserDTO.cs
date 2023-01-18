using AutoMapper;
using FluentValidation;
using GetIt.Core.Validation;
using GetIt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Users.Models
{
    [AutoMap(typeof(AppUser), ReverseMap = true)]
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class CreateUserValidator : GetItValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(NotNullMessage);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(NotNullMessage);
            RuleFor(x => x.UserName).NotEmpty().WithMessage(NotNullMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotNullMessage);
            RuleFor(x => x.Password).NotEmpty().WithMessage(NotNullMessage);
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(NotNullMessage)
                                           .Equal(a=>a.Password).WithMessage("Şifreler eşleşmelidir.");
        }
    }
}

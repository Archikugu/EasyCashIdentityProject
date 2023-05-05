using DTO.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field is required");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name field must be a maximum of 30 characters");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name field must be a minumun of 3 characters");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname field is required");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Surname field must be a maximum of 30 characters");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName field is required");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email field is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter valid e-mail address");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field is required");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password field is required");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.ConfirmPassword).WithMessage("Your passwords don't match!");
        }
    }
}

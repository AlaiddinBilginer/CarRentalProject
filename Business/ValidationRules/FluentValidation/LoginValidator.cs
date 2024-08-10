using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Password).NotEmpty();
        }
    }
}

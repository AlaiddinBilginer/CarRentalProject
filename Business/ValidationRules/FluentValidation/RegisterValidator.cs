using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8).MaximumLength(50);
            RuleFor(u => u.Password).Matches(@"[a-z]").Matches(@"[0-9]").Matches(@"[\W]").WithMessage("Şifre en az 1 adet özel karakter, 1 adet rakam, 1 adet büyük harfve 1 adet küçük harf içermelidir.");

            RuleFor(u => u.FirstName).NotEmpty();

            RuleFor(u => u.LastName).NotEmpty();
        }
    }
}

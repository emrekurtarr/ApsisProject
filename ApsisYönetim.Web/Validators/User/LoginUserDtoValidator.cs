using ApsisYönetim.Service.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.User
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email boş olamaz");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre boş olamaz");
        }
    }
}

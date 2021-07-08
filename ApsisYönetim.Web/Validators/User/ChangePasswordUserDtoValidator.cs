using ApsisYönetim.Service.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.User
{
    public class ChangePasswordUserDtoValidator : AbstractValidator<ChangePasswordUserDto>
    {
        public ChangePasswordUserDtoValidator()
        {
            RuleFor(x => x.OldPassword).NotNull().WithMessage("Eski parola boş olamaz");
            RuleFor(x => x.NewPassword).NotNull().WithMessage("Yeni parola boş olamaz");
            RuleFor(x => x.NewPasswordValidation).NotNull().WithMessage("Yeni parola onaylama boş olamaz");
            RuleFor(x => x.NewPassword).Equal(x => x.NewPasswordValidation).When(x => !String.IsNullOrWhiteSpace(x.NewPassword)).WithMessage("Yeni parola ve yeni parola onay birbirleriyle uyuşmuyor");

        }
    }
}

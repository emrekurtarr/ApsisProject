using ApsisYönetim.Service.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.User
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidator()
        {
            RuleFor(x => x.TcNo).NotNull().WithMessage("Tc Numarası boş olamaz").Length(11,11).WithMessage("Tc Numarası 11 haneli olmalıdır");
            RuleFor(x => x.Name).NotNull().WithMessage("İsim boş olamaz");
            RuleFor(x => x.Surname).NotNull().WithMessage("Soyadı boş olamaz");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Telefon numarası giriniz").Must(StartwithNumber).WithMessage("+90 ile başlamalıdır.");
            RuleFor(x => x.Username).NotNull().WithMessage("Username boş olamaz");
            RuleFor(x => x.Email).NotNull().WithMessage("Email boş olamaz").EmailAddress().WithMessage("Lütfen doğru bir email giriniz");

        }

        private bool StartwithNumber(string args)
        {
            return args.StartsWith("+90");
        }
    }
}

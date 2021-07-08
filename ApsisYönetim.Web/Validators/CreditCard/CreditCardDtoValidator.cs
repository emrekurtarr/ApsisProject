using ApsisYönetim.Service.DTOs.CreditCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.CreditCard
{
    public class CreditCardDtoValidator : AbstractValidator<CreditCardDto>
    {
        public CreditCardDtoValidator()
        {
            RuleFor(x => x.User).NotNull().WithMessage("Ad ve soyad giriniz");
            RuleFor(x => x.CardNumber).NotNull().WithMessage("Kart numarası giriniz").Length(16, 16).WithMessage("Kart numarası 16 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.ValidMonth).NotNull().WithMessage("Geçerlilik tarihi boş olamaz");
            RuleFor(x => x.ValidYear).NotNull().WithMessage("Geçerlilik tarihi boş olamaz");
            RuleFor(x => x.Cvv).NotNull().WithMessage("Cvv giriniz").Length(3,3).WithMessage("Cvv 3 karakter uzunluğunda olmalıdır.");
        }
    }
}

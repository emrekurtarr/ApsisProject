using ApsisYönetim.Service.DTOs.MonthlyCharge;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.MonthlyCharge
{
    public class AddMonthlyChargeDtoValidator : AbstractValidator<AddMonthlyChargeDto>
    {
        public AddMonthlyChargeDtoValidator()
        {
            RuleFor(x => x.ApartmentID).NotNull().WithMessage("Lütfen bir daire seçiniz");
            RuleFor(x => x.Subscription).NotNull().WithMessage("Aidat ücreti boş olamaz").GreaterThan(0).WithMessage("Aidat 0'dan büyük olmalıdır.");
            RuleFor(x => x.ElectricBill).NotNull().WithMessage("Aidat ücreti boş olamaz").GreaterThan(0).WithMessage("Aidat 0'dan büyük olmalıdır."); RuleFor(x => x.HeatingCost).NotNull().WithMessage("Aidat ücreti boş olamaz").GreaterThan(0).WithMessage("Aidat 0'dan büyük olmalıdır.");
            RuleFor(x => x.MonthOfPayment).NotNull().WithMessage("Lütfen fatura dönemi seçiniz");
        }
    }
}

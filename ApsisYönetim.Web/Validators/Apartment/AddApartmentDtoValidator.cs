using ApsisYönetim.Service.DTOs.Apartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.Apartment
{
    public class AddApartmentDtoValidator : AbstractValidator<AddApartmentDto>
    {
        public AddApartmentDtoValidator()
        {
            RuleFor(x => x.BlocNo).NotNull().WithMessage("Blok numarası boş olamaz");
            RuleFor(x => x.ApartType).NotNull().WithMessage("Daire tipi boş olamaz");
            RuleFor(x => x.FloorNo).NotNull().WithMessage("Kat numarası boş olamaz");

        }

    }
}

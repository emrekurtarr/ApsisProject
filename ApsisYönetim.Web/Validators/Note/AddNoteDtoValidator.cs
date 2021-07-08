using ApsisYönetim.Service.DTOs.Note;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Validators.Note
{
    public class AddNoteDtoValidator : AbstractValidator<AddNoteDto>
    {
        public AddNoteDtoValidator()
        {
            RuleFor(x => x.Header).NotNull().WithMessage("Başlık boş olamaz");
            RuleFor(x => x.Content).NotNull().WithMessage("Mesaj boş olamaz");
        }
    }
}

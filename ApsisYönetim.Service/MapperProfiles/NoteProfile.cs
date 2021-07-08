using ApsisYönetim.Core.Entities;
using ApsisYönetim.Service.DTOs.Note;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.MapperProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddNoteDto, Note>().ReverseMap();
            CreateMap<ShowNotesDto, Note>().ReverseMap();
        }
    }
}

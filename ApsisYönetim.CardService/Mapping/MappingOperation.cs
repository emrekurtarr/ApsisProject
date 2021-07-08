using ApsisYönetim.CardService.DTO;
using ApsisYönetim.CardService.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.CardService.Mapping
{
    public class MappingOperation : Profile
    {
        public MappingOperation()
        {
            CreateMap<CreditCardDto, CreditCard>().ReverseMap();
        }
    }
}

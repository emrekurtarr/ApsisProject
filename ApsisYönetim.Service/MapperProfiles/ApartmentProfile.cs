using ApsisYönetim.Core.Entities;
using ApsisYönetim.Service.DTOs.Apartment;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.MapperProfiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentDto, Apartment>().ReverseMap();
        }
    }
}

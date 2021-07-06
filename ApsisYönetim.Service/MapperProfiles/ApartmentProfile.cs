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
            CreateMap<Apartment , EditApartmentDto>().ForMember(dest => dest.UserId, source => source.MapFrom(x => x.User.Id));
            CreateMap<EditApartmentDto, Apartment>();
            CreateMap<AddApartmentDto, Apartment>().ReverseMap();
            CreateMap<AddChargeToApartDto, Apartment>().ReverseMap();
            CreateMap<Apartment, ListApartWithUserEmailDto>().ForMember(dest => dest.Useremail, source => source.MapFrom(x => x.User.Email));
            CreateMap<ListApartWithUserEmailDto, Apartment>();
            CreateMap<Apartment, ApartmentWithChargeDto>().ReverseMap();
        }
    }
}

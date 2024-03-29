﻿using ApsisYönetim.Core.Entities;
using ApsisYönetim.Service.DTOs.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDto, User>().ReverseMap();
            CreateMap<LoginUserDto, User>().ReverseMap();
            CreateMap<ListingUserDto, User>().ReverseMap();
            CreateMap<IndexUserDto, User>().ReverseMap();
            CreateMap<User, EditUserDto>().ReverseMap();

        }
    }
}

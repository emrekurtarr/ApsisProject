using ApsisYönetim.Core.Entities;
using ApsisYönetim.Service.DTOs.Role;
using ApsisYönetim.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ApsisYönetim.Service.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
        }  
    }
}

using ApsisYönetim.Core.Entities;
using ApsisYönetim.Service.DTOs.MonthlyCharge;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.MapperProfiles
{
    public class MonthlyChargeProfile : Profile
    {
        public MonthlyChargeProfile()
        {
            CreateMap<AddMonthlyChargeDto, MonthlyCharge>().ReverseMap();
            CreateMap<ListingMonthlyChargeDto, MonthlyCharge>().ReverseMap();
        }
    }
}

using ApsisYönetim.Service.DTOs.Apartment;
using ApsisYönetim.Service.DTOs.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.User
{
    public class ListingUserDto
    {
        public ListingUserDto()
        {
            Apartments = new List<ApartmentDto>();
        }

        public Guid Id { get; set; }
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PlakaNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public RoleDto RoleName { get; set; }

        public List<ApartmentDto> Apartments { get; set; }
        


    }
}

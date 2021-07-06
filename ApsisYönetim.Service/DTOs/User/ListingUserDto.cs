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
            UsersApartments = new List<string>();
        }

        public string Id { get; set; }
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlakaNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public List<string> UsersApartments { get; set; }
        


    }
}

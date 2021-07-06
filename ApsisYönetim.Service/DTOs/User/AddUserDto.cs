using ApsisYönetim.Service.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.User
{
    public class AddUserDto
    {
        
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlakaNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        //public List<RoleDto> Roles{ get; set; }
        //public List<ApartmentDto> Apartments{ get; set; }
    }
}

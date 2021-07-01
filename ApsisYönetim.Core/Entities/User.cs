using ApsisYönetim.Core.Interfaces.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Entities
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            Apartments = new List<Apartment>();
            Roles = new List<Role>();
        }

        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlakaNo { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<Role> Roles { get;set; }
    }
}


using ApsisYönetim.Core.Interfaces.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Entities
{
    public class Role : IdentityRole,IEntity
    {
        public Role()
        {
            Users = new List<User>();
        }

        public virtual ICollection<User> Users { get; set; }
    }

    public enum Roles
    {
        Admin,
        User
    }
}

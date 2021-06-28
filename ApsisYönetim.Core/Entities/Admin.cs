using ApsisYönetim.Core.Interfaces.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Entities
{
    public class Admin : IdentityUser,IEntity
    {
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

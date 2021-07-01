using ApsisYönetim.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class RoleController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


    }
}

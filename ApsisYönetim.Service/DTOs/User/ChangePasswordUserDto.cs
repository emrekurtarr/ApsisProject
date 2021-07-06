using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.User
{
    public class ChangePasswordUserDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordValidation { get; set; }
    }
}

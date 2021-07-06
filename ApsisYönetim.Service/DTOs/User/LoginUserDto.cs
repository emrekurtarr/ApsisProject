using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.User
{
    public class LoginUserDto
    {

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="{0} alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

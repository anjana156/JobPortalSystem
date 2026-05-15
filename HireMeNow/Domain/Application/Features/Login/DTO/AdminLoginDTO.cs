using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.Login.DTO
{
    public class AdminLoginDTO
    {
        public string Email { get; set; }
        [Required]
        /*   public string Password { get; set; }*/

        public string? Token { get; set; }
    }
}

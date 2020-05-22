using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Web.Models.UserM
{
    public class CreateUserM
    {
        [Required(ErrorMessage = "Bạn phải nhập User")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "User phải nhập từ 2>50 ký tự")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Password")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Password phải nhập từ 2>50 ký tự")]
        public string Password { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPark.Models.RequestModel.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Zorunlu")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

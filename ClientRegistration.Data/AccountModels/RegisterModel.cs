﻿using System.ComponentModel.DataAnnotations;

namespace ClientRegistration.Data.AccountModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

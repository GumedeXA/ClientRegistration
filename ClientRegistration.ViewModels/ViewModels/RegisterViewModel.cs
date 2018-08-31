﻿using System.ComponentModel.DataAnnotations;

namespace Wave28.ViewModels.ViewModels
{
    public class RegisterViewModel
    {

        public string RegisterId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Please provide a valid  email address.")]
        public string Email { get; set; }

        //Added Field
        [Required]
        [Display(Name = "full Names")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter name that consist of letters only")]
        public string fullNames { get; set; }

        //Added Field
        [Required]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string phoneNumber { get; set; }
        
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }

        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

    }
}

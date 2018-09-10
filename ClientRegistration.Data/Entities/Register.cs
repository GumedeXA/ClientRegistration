using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientRegistration.Data.Entities
{
    public class Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "RSA ID")]
        [StringLength(13, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 13)]
        public string IdNumber { get; set; }

        //Added Field
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }

        //Added Field
        [Required]
        [Display(Name = "full Names")]
        public string fullNames { get; set; }

        //Added Field
        [Required]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

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

        public DateTime RegistrationDate { get; set; }

    }
}

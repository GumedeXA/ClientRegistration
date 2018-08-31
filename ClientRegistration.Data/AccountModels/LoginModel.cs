using System.ComponentModel.DataAnnotations;

namespace Wave28.Data.AccountModels
{
     public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string Role { get; set; }

    }
}

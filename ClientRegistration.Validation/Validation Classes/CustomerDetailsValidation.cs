using ClientRegistration.BusinessLogic.Logic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ClientRegistration.Validation.Validation_Classes
{
    public  class CustomerDetailsValidation 
    {
        public sealed class UserNameExistance : ValidationAttribute
        {
            protected override ValidationResult IsValid(object userName, ValidationContext validationContext)
            {
                try
                {
                    RegisterBusinessLogic db = new RegisterBusinessLogic();
                    int result = db.GetAllRegisteredUsers().ToList().
                    Where(user => user.userName.Equals(userName)).Count();
                    if (result==0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("User Name Already Exist");
                    }
                   
                }
                catch (System.Exception ex)
                {
                    throw ex.InnerException;
                }

            }
         
        }
        
    }
}

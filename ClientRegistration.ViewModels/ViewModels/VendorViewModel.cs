using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientRegistration.ViewModels.ViewModels
{
    public class VendorViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vendorId { get; set; }
        [Required]
        [Display(Name = "Registration Number")]
        public string VendorRegNo { get; set; }
        [Required]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Required]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string VendorEmail { get; set; }
        [Required]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        //Referential Integrity
        public int BusAdminId { get; set; }
        public virtual BusinessAdminViewModel BusinessAdminViewModel { get; set; }
    }
}

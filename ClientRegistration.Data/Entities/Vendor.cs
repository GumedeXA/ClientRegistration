using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientRegistration.Data.Entities
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vendorId { get; set; }
        [Required]
        public string VendorRegNo { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Required]
        public string VendorPostalAddress { get; set; }
        [Required]
        public string VendorEmail { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        public string Other { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}

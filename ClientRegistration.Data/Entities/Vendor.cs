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
        public string VendorRegNo { get; set; }
        public string VendorName { get; set; }
        public string VendorPostalAddress { get; set; }
        public string VendorEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public string Other { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

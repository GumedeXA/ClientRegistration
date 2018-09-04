using System;
using System.ComponentModel.DataAnnotations;

namespace ClientRegistration.Data.Entities
{
    public class Vendor
    {
        [Key]
        public int vendorId { get; set; }
        public string VendorRegNo { get; set; }
        public string VendorName { get; set; }
        public string PostalAddress { get; set; }
        public string VendorEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        //Referential Integrity
        public int BusAdminId { get; set; }
        public virtual BusinessAdmin BusinessAdmin { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ClientRegistration.Data.Entities
{
    public class VendorProduct
    {
        [Key]
        public int vendorProductId { get; set; }
        public int vendorId { get; set; }
        public int ProductId { get; set; }
        public string VendorRegNo { get; set; }
        public string VendorName { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual Product Product { get; set; }
    }
}

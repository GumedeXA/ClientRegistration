using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientRegistration.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId{ get; set; }
        public string ProductName { get; set; }
        public double ProductPrice{ get; set; }
        public DateTime DateAdded { get; set; }
        public double Discount { get; set; }
        public byte[] ProductImage { get; set; }
        public int ProductTypeId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual Category Category { get; set; }

    }
}

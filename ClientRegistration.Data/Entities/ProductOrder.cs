using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClientRegistration.Data.Entities
{
   public class ProductOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductOrderId { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}

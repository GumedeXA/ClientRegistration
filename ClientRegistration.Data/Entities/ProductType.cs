using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClientRegistration.Data.Entities
{
   public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

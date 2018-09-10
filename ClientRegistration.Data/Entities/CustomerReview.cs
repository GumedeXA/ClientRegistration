using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClientRegistration.Data.Entities
{

    public class CustomerReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerReviewId{ get; set; }

        public int CustId { get; set; }
        public int ReviewId { get; set; }
        public int Ratings { get; set; }
        public DateTime PublishedDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Review Review { get; set; }
    }
}

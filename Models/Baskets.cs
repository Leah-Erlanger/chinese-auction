using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    public class Baskets
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int GiftId { get; set; }
        public int Numgift { get; set; }
        public bool IsDraft { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customers? Customers { get; set; }
        [ForeignKey("GiftId")]
        public virtual Gifts? Gifts { get; set; }
    }
}


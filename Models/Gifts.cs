using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    public class Gifts
    {
        [Key]
        public int Id { get; set; }
        public string NameGift { get; set; }
        public int DonorId{ get; set; }
        public int PriceTicket { get; set; }
        public int CategoryId  { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int NumBuyers  { get; set; }
       
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [ForeignKey("DonorId")]
        public virtual Donors? Donors { get; set; }

        internal static List<GiftMask> ToList()
        {
            throw new NotImplementedException();
        }
    }
}

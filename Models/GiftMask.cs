using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models
{
    public class GiftMask
    {
        [Key]
        public int Id { get; set; }
        public string NameGift { get; set; }
        public string DonorName{ get; set; }
        public int PriceTicket { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int NumBuyers { get; set; }
    }

}

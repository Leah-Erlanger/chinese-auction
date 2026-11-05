using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models
{
    public class Donors
    {
        [Key]
        public int Id { get; set; }
        public string NameDonor { get; set; }
        public string EmailDonor { get; set; }
        public string? PhoneDonor { get; set; }
        public virtual ICollection<Gifts> GiftListForDonor { get; set; } = new List<Gifts>();
    }
}

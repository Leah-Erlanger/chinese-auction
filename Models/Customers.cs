using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public string NameCustomer { get; set; }
        public string EmailCustomer { get; set; }
        public string? PhoneCustomer { get; set; }
        public string? Adress { get; set; }
        public bool IsManager { get; set; }
    }
}

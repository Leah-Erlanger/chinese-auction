using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string NameCategory { get; set; }
    }
}
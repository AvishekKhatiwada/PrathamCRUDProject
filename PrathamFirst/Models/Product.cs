using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrathamFirst.Models
{
    [Table("Product")]
    public class Product
    {
        public long Id { get; set; }
        public String? Image { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Stock { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Size { get; set; }
        [Required]
        public decimal? Price { get; set; }

       


    }
}
 
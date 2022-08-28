using System.ComponentModel.DataAnnotations.Schema;

namespace PrathamFirst.Models
{
    [Table("Product")]
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Stock { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

    }
}

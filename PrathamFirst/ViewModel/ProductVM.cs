using PrathamFirst.Models;
using System.ComponentModel.DataAnnotations;

namespace PrathamFirst.ViewModel
{
    public class ProductVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Stock { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }
    }
}

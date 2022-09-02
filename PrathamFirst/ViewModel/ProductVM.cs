using PrathamFirst.Models;
using System.ComponentModel.DataAnnotations;

namespace PrathamFirst.ViewModel
{
    public class ProductVM
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Stock Value!")]
        public string? Stock { get; set; }

        [Required(ErrorMessage = "Please Enter Product Color!")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Please Choose Product Size!")]
        public string? Size { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price!")]
        public decimal? Price { get; set; }

        public IFormFile Image { get; set; }
    }
}

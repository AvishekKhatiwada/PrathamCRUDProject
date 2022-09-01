using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrathamFirst.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        [Required]
        public string Password { get; set; }
        public String? Image { get; set; }
    }
}

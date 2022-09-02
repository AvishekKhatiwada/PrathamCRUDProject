using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrathamFirst.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string Password { get; set; }
        public String? Image { get; set; }
    }
}

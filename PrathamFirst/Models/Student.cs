using System.ComponentModel.DataAnnotations;
namespace PrathamFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        //public Student() 
        //{ 
        //    Id = 101;
        //    Name = "Avishek Khatiwada";
        //    Address = "Chandragadhi";
        //}
    }
}

using System.ComponentModel.DataAnnotations;

namespace RazorPagesLessons.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field can not be null!")]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please, enter valid email (format: example@exem.com)")]
        [MaxLength(50), MinLength(2)]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}

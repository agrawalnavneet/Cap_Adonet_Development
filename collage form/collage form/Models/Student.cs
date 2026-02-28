using System;
using System.ComponentModel.DataAnnotations;

namespace collage_form.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$",
            ErrorMessage = "Name cannot contain numbers")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(17, 100,
            ErrorMessage = "Age must be greater than 16")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$",
            ErrorMessage = "Father name cannot contain numbers")]
        public string FatherName { get; set; } = string.Empty;

        [Required]
        public string Place { get; set; } = string.Empty;
    }
}
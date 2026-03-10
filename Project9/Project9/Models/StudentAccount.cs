using System.ComponentModel.DataAnnotations;
namespace Project9.Models
{
    public class StudentAccount
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Student Student { get; set; }

    }
}

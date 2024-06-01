using System.ComponentModel.DataAnnotations;

namespace BBWebProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Enter Your UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage =" Enter Your Password")]
        public string Password { get; set; }
    }
}

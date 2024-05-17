using System.ComponentModel.DataAnnotations;

namespace BBWebProject.Models
{
    public class Profile
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Enter PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Enter Email")]
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }
    }
}

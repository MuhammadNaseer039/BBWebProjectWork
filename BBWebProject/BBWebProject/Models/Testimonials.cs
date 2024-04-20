using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBWebProject.Models
{
    public class Testimonials
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter Profession")]
        public string Profession { get; set; }
        [Required(ErrorMessage ="Please Enter review")]
        public string Review { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}

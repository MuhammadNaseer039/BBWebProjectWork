using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BBWebProject.Models
{
    public class Testimonial
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter Profession")]
        public string Profession { get; set; }
        [Required(ErrorMessage ="Please Enter review")]
        public string Review { get; set; }
        [MaybeNull]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}

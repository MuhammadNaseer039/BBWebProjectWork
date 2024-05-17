using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBWebProject.Models
{
    public class Non_Variated_Items
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please Enter Price")]
        public string Price { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}

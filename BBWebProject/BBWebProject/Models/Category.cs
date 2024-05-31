using System.ComponentModel.DataAnnotations;

namespace BBWebProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Category Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Category Slug")]
        public string Slug { get; set; }
        [Required]
        public bool status { get; set; }

    }
}

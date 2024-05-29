using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Category> categories { get; set; }
        public List<Chief> chief { get; set; }
        public List<Testimonial> testimonials { get; set; }
        public Profile profile { get; set; }
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            chief=db.tbl_chief.ToList();
            categories = db.tbl_category.ToList();
            testimonials = db.tbl_testimonials.OrderByDescending(x => x.ID).Take(4).OrderBy(x => x.ID).ToList();
            profile = db.tbl_profile.FirstOrDefault();

        }
    }
}

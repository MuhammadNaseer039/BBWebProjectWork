using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.HomePages
{
    public class TestimonialModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Category> categories { get; set; }
        public Profile profile { get; set; }
        public TestimonialModel(BBWebDbContext _db)
        {
            db = _db;
        }
       
        public void OnGet()
        {
            categories = db.tbl_category.ToList();
            profile = db.tbl_profile.FirstOrDefault();

        }
    }
}

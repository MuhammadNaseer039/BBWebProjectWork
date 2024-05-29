using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages
{
    public class FeedbackModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Testimonial testimonial { get; set; }

        public FeedbackModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {

        }
        
        public IActionResult OnPostCreate(Testimonial testimonial)
        {
            db.tbl_testimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToPage("Feedback");
        }
    }
}

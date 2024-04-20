using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Testimonials
{
    public class AddTestimonialsModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        public Testimonial testimonial { get; set; }
        public AddTestimonialsModel(BBWebDbContext _db, IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;

        }
        public void OnGet()
        {
        }
        [HttpPost]
        public IActionResult OnPost(Testimonial testimonial)
        {
            Testimonial test = new Testimonial();
            test.Name = testimonial.Name;
            test.Profession = testimonial.Profession;
            test.Review = testimonial.Review;
            test.Image = testimonial.Photo.FileName;

            var folder = Path.Combine(env.WebRootPath,"images");
            var imagepath = Path.Combine(folder,testimonial.Photo.FileName);
            testimonial.Photo.CopyTo(new FileStream(imagepath,FileMode.Create));

            db.tbl_testimonials.Add(test);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

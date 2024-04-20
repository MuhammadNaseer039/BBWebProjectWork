using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Testimonials
{
    public class UpdateTestimonialsModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        public Testimonial testimonial {  get; set; }
        public UpdateTestimonialsModel(BBWebDbContext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet(int id)
        {
            testimonial = db.tbl_testimonials.Find(id);
        }
        public IActionResult OnPost(Testimonial testimonial)
        {
            Testimonial test = new Testimonial();
            test.ID = testimonial.ID;
            test.Name = testimonial.Name;
            test.Profession = testimonial.Profession;
            test.Review = testimonial.Review;

            if(testimonial.Photo != null)
            {
                test.Image = testimonial.Photo.FileName;
                var folder = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folder, testimonial.Photo.FileName);
                testimonial.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));
            }
            else
            {
                test.Image = testimonial.Image;
            }

            db.tbl_testimonials.Update(test);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

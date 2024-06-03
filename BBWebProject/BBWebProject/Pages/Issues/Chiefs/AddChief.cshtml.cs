using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Chiefs
{
    public class AddChiefModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        public Chief chief { get; set; }
        public string Name = "";
        public AddChiefModel(BBWebDbContext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet()
        {
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostCreate(Chief chief)
        {
            Chief chief1 = new Chief();
            chief1.Name = chief.Name;
            chief1.Designation = chief.Designation;
            chief1.Facebook = chief.Facebook;
            chief1.Instagram = chief.Instagram;
            chief1.Twitter = chief.Twitter;
            chief1.Image = chief.Photo.FileName;

            var folderpath = Path.Combine(env.WebRootPath, "images");
            var imagepath = Path.Combine(folderpath, chief.Photo.FileName);
            chief.Photo.CopyTo(new FileStream(imagepath,FileMode.Create));

            db.tbl_chief.Add(chief1);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

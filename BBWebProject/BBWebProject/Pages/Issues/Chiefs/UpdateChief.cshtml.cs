using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Chiefs
{
    public class UpdateChiefModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;

        public Chief chief { get; set; }
        public string Name = "";

        public UpdateChiefModel(BBWebDbContext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet(int id)
        {
            chief = db.tbl_chief.Find(id);
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostUpdate(Chief chief)
        {
            Chief chief1 = new Chief();
            chief1.Id = chief.Id;
            chief1.Name = chief.Name;
            chief1.Designation = chief.Designation;
            chief1.Facebook = chief.Facebook;
            chief1.Instagram  = chief.Instagram;
            chief1.Twitter = chief.Twitter;

            if(chief.Photo != null)
            {
                chief1.Image = chief.Photo.FileName;
                var folderpath = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folderpath, chief.Photo.FileName);
                chief.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));
            }
            else
            {
                chief1.Image = chief.Image;
            }
            db.tbl_chief.Update(chief1);
            db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

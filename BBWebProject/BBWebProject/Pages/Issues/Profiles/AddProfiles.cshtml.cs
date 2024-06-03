using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Profiles
{
    public class AddProfilesModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Profile profile { get; set; }
        public string Name = "";
        public AddProfilesModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostCreate(Profile profile)
        {
            db.tbl_profile.Add(profile);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

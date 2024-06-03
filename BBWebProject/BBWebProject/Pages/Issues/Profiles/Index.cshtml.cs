using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Profiles
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Profile> profiles { get; set; }
        public Profile profile { get; set; }
        public string Name = "";
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            profiles = db.tbl_profile.ToList();
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostDelete(int id)
        {
            profile = db.tbl_profile.Find(id);
            db.tbl_profile.Remove(profile);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Issues/Login");
        }

    }
}

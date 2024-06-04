using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace BBWebProject.Pages.Issues.Chiefs
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Chief> chiefs { get; set; }
        public Chief chief { get; set; }
        public string Name = "";
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            chiefs = db.tbl_chief.ToList();
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostDelete(int id)
        {
            chief = db.tbl_chief.Find(id);
            db.tbl_chief.Remove(chief);
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

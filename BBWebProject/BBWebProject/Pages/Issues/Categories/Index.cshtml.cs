using BBWebProject.Data;
using BBWebProject.Migrations;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Categories
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Category> categories {  get; set; }
        public Category category { get; set; }
        public string Name = "";
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            categories = db.tbl_category.ToList();
            Name = HttpContext.Session.GetString("Name");
        }

        public IActionResult OnPostDelete(int id)
        {
            category = db.tbl_category.Find(id);
            db.tbl_category.Remove(category);
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

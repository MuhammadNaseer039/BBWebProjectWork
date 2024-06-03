using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace BBWebProject.Pages.Issues.Categories
{
    public class AddCategoriesModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Category category { get; set; }
        public string Name = "";
        public AddCategoriesModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Name = HttpContext.Session.GetString("Name");
        }
        public IActionResult OnPostCreate(Category category)
        {
            db.tbl_category.Add(category);
            db.SaveChanges();
            return RedirectToPage("Index");
        }

    }
}

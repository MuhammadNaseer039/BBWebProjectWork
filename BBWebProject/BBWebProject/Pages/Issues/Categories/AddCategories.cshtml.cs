using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Categories
{
    public class AddCategoriesModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Category category { get; set; }
        public AddCategoriesModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPostCreate(Category category)
        {
            db.tbl_category.Add(category);
            db.SaveChanges();
            return RedirectToPage("Index");
        }

    }
}

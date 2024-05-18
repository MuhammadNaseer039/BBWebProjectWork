using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BBWebProject.Pages.Issues.Categories
{
    public class UpdateCategoriesModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Category category { get; set; }
        public UpdateCategoriesModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet(int id)
        {
            category = db.tbl_category.Find(id);
        }
        public IActionResult OnPostUpdate(Category category)
        {
            Category cat = new Category();
            cat.Id = category.Id;
            cat.Name = category.Name;
            cat.Description = category.Description;
            cat.Slug = category.Slug;
            db.tbl_category.Update(cat);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

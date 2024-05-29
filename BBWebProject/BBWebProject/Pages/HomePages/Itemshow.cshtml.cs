using BBWebProject.Data;
using BBWebProject.Migrations;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.HomePages
{
    public class ItemshowModel : PageModel
    {
        BBWebDbContext db;
        public List<Category> categories { get; set; }
        public ItemshowModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            categories = db.tbl_category.ToList();
        }
    }
}

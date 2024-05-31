using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace BBWebProject.Pages.HomePages
{
    public class ItemsModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Category> categories { get; set; }
        public Profile profile { get; set; }
        public string title = "";
        public ItemsModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet(string slug)
        {
            title = "Special Pizza";
            categories = db.tbl_category.ToList();
            profile = db.tbl_profile.FirstOrDefault();

        }
    }
}

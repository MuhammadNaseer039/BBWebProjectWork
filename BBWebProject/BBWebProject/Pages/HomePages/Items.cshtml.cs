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
        public List<Non_Variated_Items> Items { get; set; }
        public List<Variated_Items> variated_items { get; set; }
        public Category category { get; set; }
        public Profile profile { get; set; }
        public string title = "";
        public bool status = false;
        public ItemsModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet(string slug)
        {
            category = db.tbl_category.Where(s => s.Slug == slug).FirstOrDefault();

            if(category.status)
            {
                variated_items = db.tbl_variated_items.Where(x => x.CategoryId == category.Id).ToList();
                status = true;
            }
            else
            {
                Items = db.tbl_non_variated_items.Where(s => s.CategoryId == category.Id).ToList();
            }

            title = category.Name;
            
            categories = db.tbl_category.ToList();
            profile = db.tbl_profile.FirstOrDefault();

        }
    }
}

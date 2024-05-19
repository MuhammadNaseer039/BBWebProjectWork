using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.HomePages
{
    public class ContactModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Category> categories { get; set; }
        
        public ContactModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            categories = db.tbl_category.ToList();
        }
    }
}

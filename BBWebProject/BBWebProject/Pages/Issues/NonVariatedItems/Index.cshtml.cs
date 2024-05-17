using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Items
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;

        public List<Non_Variated_Items> items {  get; set; }
        public Non_Variated_Items itemdelete { get; set; }
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            items = db.tbl_non_variated_items.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            itemdelete = db.tbl_non_variated_items.Find(id);
            db.tbl_non_variated_items.Remove(itemdelete);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Items
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;

        public List<Item> items {  get; set; }
        public Item itemdelete { get; set; }
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            items = db.tbl_item.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            itemdelete = db.tbl_item.Find(id);
            db.tbl_item.Remove(itemdelete);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

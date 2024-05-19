using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.VariatedItems
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;

        public List<Variated_Items> variateditems { get; set; }
        public Variated_Items itemtoremove { get; set; }

        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }

        public void OnGet()
        {
            variateditems = db.tbl_variated_items.ToList();
        }
        public IActionResult OnPostDelete(int id)
        {
            itemtoremove = db.tbl_variated_items.Find(id);
            db.tbl_variated_items.Remove(itemtoremove);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Chiefs
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public List<Chief> chiefs { get; set; }
        public Chief chief { get; set; }
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            chiefs = db.tbl_chief.ToList();
        }
        public IActionResult OnPostDelete(int id)
        {
            chief = db.tbl_chief.Find(id);
            db.tbl_chief.Remove(chief);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

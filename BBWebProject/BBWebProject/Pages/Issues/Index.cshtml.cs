using BBWebProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues
{
    public class IndexModel : PageModel
    {
        private readonly BBWebDbContext db;
        public IndexModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public int NonVariatedItems,VariatedItems,Categories,Chiefs;
        public void OnGet()
        {
            var nonvariateditems = from rows in db.tbl_non_variated_items select rows;
            NonVariatedItems = nonvariateditems.Count();

            var variateditems = from rows in db.tbl_variated_items select rows;
            VariatedItems = variateditems.Count();

            var categories = from rows in db.tbl_category select rows;
            Categories = categories.Count();

            var chiefs = from rows in db.tbl_chief select rows;
            Chiefs = chiefs.Count();
        }
    }
}

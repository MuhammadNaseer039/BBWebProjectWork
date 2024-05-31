using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.VariatedItems
{
    public class AddItemsModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        public Variated_Items variateditem { get; set; }
        public List<Category> categories { get; set; }
        public AddItemsModel(BBWebDbContext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet()
        {
            categories = db.tbl_category.ToList();
        }
        public IActionResult OnPostCreate(Variated_Items variateditem)
        {
            Variated_Items newitem = new Variated_Items();
            newitem.Title = variateditem.Title;
            newitem.Description = variateditem.Description;
            newitem.Regular = variateditem.Regular;
            newitem.Large = variateditem.Large;
            newitem.Medium = variateditem.Medium;
            newitem.Small = variateditem.Small;
            newitem.CategoryId = variateditem.CategoryId;
            newitem.Image = variateditem.Photo.FileName;

            var folderpath = Path.Combine(env.WebRootPath, "images");
            var imagepath = Path.Combine(folderpath, variateditem.Photo.FileName);
            variateditem.Photo.CopyTo(new FileStream(imagepath,FileMode.Create));

            db.tbl_variated_items.Add(newitem);
            db.SaveChanges();

            return RedirectToPage("AddItems");
        }
    }
}

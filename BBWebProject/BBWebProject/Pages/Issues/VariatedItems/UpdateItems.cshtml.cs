using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BBWebProject.Pages.Issues.VariatedItems
{
    public class UpdateItemsModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        public Variated_Items variateditem { get; set; }
        public List<Category> categories { get; set; }
        public UpdateItemsModel(BBWebDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet(int id)
        {
            variateditem = db.tbl_variated_items.Find(id);
            categories = db.tbl_category.ToList();
        }

        public IActionResult OnPostUpdate(Variated_Items variateditem)
        {
            Variated_Items updateitem = new Variated_Items();
            updateitem.ID = variateditem.ID;
            updateitem.Title = variateditem.Title;
            updateitem.Description = variateditem.Description;
            updateitem.Regular = variateditem.Regular;
            updateitem.Large = variateditem.Large;
            updateitem.Medium = variateditem.Medium;
            updateitem.Small = variateditem.Small;
            updateitem.CategoryId = variateditem.CategoryId;

            if(variateditem.Photo != null)
            {
                updateitem.Image = variateditem.Photo.FileName;
                var folderpath = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folderpath, variateditem.Photo.FileName);
                variateditem.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));
            }
            else
            {
                updateitem.Image = variateditem.Image;
            }

            db.tbl_variated_items.Update(updateitem);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

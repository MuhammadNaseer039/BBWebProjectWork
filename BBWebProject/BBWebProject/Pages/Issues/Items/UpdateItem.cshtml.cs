using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Items
{
    public class UpdateItemModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        public Item items {  get; set; }
        public UpdateItemModel(BBWebDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public void OnGet(int id)
        {
            items = db.tbl_item.Find(id);
        }
        [HttpPost]
        public IActionResult OnPostUpdate(Item items)
        {
            Item update = new Item();
            update.Id = items.Id;
            update.Title = items.Title;
            update.Description = items.Description;
            update.Price = items.Price;

            if(items.Photo != null)
            {
                update.Image = items.Photo.FileName;
                var folder = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folder, items.Photo.FileName);
                items.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));
            }
            else
            {
                update.Image = items.Image;
            }
            db.tbl_item.Update(update);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

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
        public Non_Variated_Items items {  get; set; }
        public string Name = "";
        public UpdateItemModel(BBWebDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public void OnGet(int id)
        {
            items = db.tbl_non_variated_items.Find(id);
            Name = HttpContext.Session.GetString("Name");
        }
        [HttpPost]
        public IActionResult OnPostUpdate(Non_Variated_Items items)
        {
            Non_Variated_Items update = new Non_Variated_Items();
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
            db.tbl_non_variated_items.Update(update);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BBWebProject.Pages.Issues.Items
{
    public class AddItemModel : PageModel
    {
        private readonly BBWebDbContext db;
        private readonly IWebHostEnvironment env;
        [BindProperty]
        public Non_Variated_Items items { get; set; }
        public AddItemModel(BBWebDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostCreate(Non_Variated_Items items) 
        {
            Non_Variated_Items newitem = new Non_Variated_Items();
            newitem.Title = items.Title;
            newitem.Description = items.Description;
            newitem.Price = items.Price;
            newitem.Image = items.Photo.FileName;

            var folder = Path.Combine(env.WebRootPath, "images");
            var imagepath = Path.Combine(folder,items.Photo.FileName);
            items.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));

            db.tbl_non_variated_items.Add(newitem);
            db.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}

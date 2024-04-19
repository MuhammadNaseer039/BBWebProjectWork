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
        public Item items { get; set; }
        public AddItemModel(BBWebDbContext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostCreate(Item items) 
        {
            Item newitem = new Item();
            newitem.Title = items.Title;
            newitem.Description = items.Description;
            newitem.Price = items.Price;
            newitem.Image = items.Photo.FileName;

            var folder = Path.Combine(env.WebRootPath, "images");
            var imagepath = Path.Combine(folder,items.Photo.FileName);
            items.Photo.CopyTo(new FileStream(imagepath, FileMode.Create));

            db.tbl_item.Add(newitem);
            db.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}

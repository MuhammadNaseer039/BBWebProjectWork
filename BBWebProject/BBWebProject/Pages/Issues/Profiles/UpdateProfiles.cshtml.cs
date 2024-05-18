using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues.Profiles
{
    public class UpdateProfilesModel : PageModel
    {
        private readonly BBWebDbContext db;
        public Profile profile { get; set; }
        public UpdateProfilesModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet(int id)
        {
            profile = db.tbl_profile.Find(id);
        }

        public IActionResult OnPostUpdate(Profile profile)
        {
            Profile pro = new Profile();
            pro.Id = profile.Id;
            pro.Address = profile.Address;
            pro.PhoneNumber = profile.PhoneNumber;
            pro.Email = profile.Email;
            pro.Facebook = profile.Facebook;
            pro.Instagram = profile.Instagram;
            pro.Youtube = profile.Youtube;
            pro.Twitter = profile.Twitter;
            db.tbl_profile.Update(pro);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

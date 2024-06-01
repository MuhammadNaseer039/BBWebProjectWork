using BBWebProject.Data;
using BBWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBWebProject.Pages.Issues
{
    public class LoginModel : PageModel
    {
        private readonly BBWebDbContext db;
        public User user { get; set; }
        public LoginModel(BBWebDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPostLogin(User user)
        {
            if(ModelState.IsValid)
            {
                User user1 = new();
                user1 = db.tbl_users.FirstOrDefault();
                if (user.UserName == user1.UserName && user.Password == user1.Password)
                {
                    HttpContext.Session.SetString("username", user.UserName);
                    HttpContext.Session.SetString("Name" ,user.FullName);
                    HttpContext.Session.SetString("Access", "True");
                    return RedirectToPage("/Issues/Index");
                }
                else
                {
                    return Page();
                }
                
            }
            else
            {
                return Page();
            }
            
        }
    }
}

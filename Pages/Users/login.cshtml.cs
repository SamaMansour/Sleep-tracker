using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sleep_tracker.Data;
using sleep_tracker.Model;

namespace sleep_tracker.Pages.Users
{
    public class loginModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public User user { get; set; }


        public loginModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            try
            {
                // Verification.
                if (this.User.Identity.IsAuthenticated)
                {
                    // Home Page.
                    return this.RedirectToPage("Index");
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.Page();
        }
        public async Task<IActionResult> OnPostLogIn(User user)
        {
            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    // Initialization.
                    var loginInfo = await this._db.User.FindAsync(this.user.Email, this.user.Password);

                    // Verification.
                    if (loginInfo != null)
                    {
                       


                        // Info.
                        return this.RedirectToPage("Index");
                    }
                    else
                    {
                        // Setting.
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.Page();

        }
    }
}

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
    public class signupModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public User user { get; set; }


        public signupModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(User user)
        {
            
            if (ModelState.IsValid)
            {
                await _db.User.AddAsync(user);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

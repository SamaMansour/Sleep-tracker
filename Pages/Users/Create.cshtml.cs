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
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public Record record { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Record record)
        {
          
            if (ModelState.IsValid)
            {
                await _db.Record.AddAsync(record);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
       
    }
}

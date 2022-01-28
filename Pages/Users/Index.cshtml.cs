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
    public class IndexModel : PageModel
    {


        private readonly ApplicationDbContext _db;
        public IEnumerable<Record> Records { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
            Records = _db.Record;
        }
       
    }
}

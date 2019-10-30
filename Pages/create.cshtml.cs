using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CustCRUD.Pages
{
    public class createModel : PageModel
    {
        private readonly AppDbContext _db;

        private ILogger<createModel> Log;

        public createModel(AppDbContext db, ILogger<createModel> log)
        {
            _db = db;
            Log = log;
        }

        [TempData]
        public string message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _db.Customer.Add(Customer);
            await _db.SaveChangesAsync();
            var msg = $"Customer {Customer.Name} Added!";
            message = msg;
            Log.LogCritical(msg);

            return RedirectToPage("/Index");

        }
    }
}

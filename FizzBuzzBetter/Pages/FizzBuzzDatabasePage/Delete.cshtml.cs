using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using FizzBuzzBetter.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzBetter.Pages.FizzBuzzDatabasePage
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public DeleteModel(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Fizzbuzz Fizzbuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fizzbuzz = await _context.Fizzbuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (Fizzbuzz == null || Fizzbuzz.CreatedBy == null || !Fizzbuzz.CreatedBy.Equals(_userManager.GetUserName(User)))
            {
                return RedirectToPage("./RecentlySearched");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fizzbuzz = await _context.Fizzbuzz.FindAsync(id);

            if (Fizzbuzz != null)
            {                
                _context.Fizzbuzz.Remove(Fizzbuzz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./RecentlySearched");
        }
    }
}

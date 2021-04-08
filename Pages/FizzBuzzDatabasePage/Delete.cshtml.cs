using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzz.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzz.Data.FizzBuzzContext _context;

        public DeleteModel(FizzBuzz.Data.FizzBuzzContext context)
        {
            _context = context;
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

            if (Fizzbuzz == null)
            {
                return NotFound();
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

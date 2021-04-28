using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using FizzBuzzBetter.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzBetter.Pages.FizzBuzzDatabasePage
{
    [Authorize]
    public class RecentlySearchedModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RecentlySearchedModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fizzbuzz> FizzBuzz { get; set; }

        public void OnGet()
        {
            FizzBuzz = _context.Fizzbuzz
                .OrderByDescending(p => p.Date)
                .Take(20)
                .ToList();
        }
    }
}

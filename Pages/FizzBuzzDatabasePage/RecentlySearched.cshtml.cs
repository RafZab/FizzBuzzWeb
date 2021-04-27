using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Data;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzz.Pages
{
    public class RecentlySearchedModel : PageModel
    {

        private readonly FizzBuzzContext _context;

        public RecentlySearchedModel(FizzBuzzContext context)
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

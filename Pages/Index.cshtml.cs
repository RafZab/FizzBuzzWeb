using FizzBuzz.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;


namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;

        [BindProperty]
        public Fizzbuzz FizzBuzz { get; set; }

        public List<Fizzbuzz> NumbersList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

       public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NumberListSessionJSON = HttpContext.Session.GetString("NumberListSession");
            if (NumberListSessionJSON != null)
                NumbersList = JsonConvert.DeserializeObject<List<Fizzbuzz>>(NumberListSessionJSON);
            else
                NumbersList = new List<Fizzbuzz>();

            FizzBuzz.CheckDisivibility();

            _context.Fizzbuzz.Add(FizzBuzz);        // Adding in Datebase
            _context.SaveChanges();

            NumbersList.Add(FizzBuzz);              // Adding in Session

            HttpContext.Session.SetString("NumberListSession", JsonConvert.SerializeObject(NumbersList));           
            return Page();
        }
    }
}

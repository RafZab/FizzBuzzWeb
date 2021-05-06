using FizzBuzz.Models;
using FizzBuzzBetter.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FizzBuzzBetter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Fizzbuzz FizzBuzz { get; set; }

        public List<Fizzbuzz> NumbersList { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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

            SaveInDatabase();

            NumbersList.Add(FizzBuzz);              // Adding in Session

            HttpContext.Session.SetString("NumberListSession", JsonConvert.SerializeObject(NumbersList));
            return Page();
        }

        private void SaveInDatabase()
        {
            if (_signInManager.IsSignedIn(User))
            {
                _context.Fizzbuzz.Add(FizzBuzz);        // Adding in Datebase
                FizzBuzz.CreatedBy = _userManager.GetUserName(User);
                _context.SaveChanges();
            }
        }
    }
}

using FizzBuzz.Scripts;
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

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzbuzzApp FizzBuzz { get; set; }

        public List<FizzbuzzApp> NumbersList { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
                NumbersList = JsonConvert.DeserializeObject<List<FizzbuzzApp>>(NumberListSessionJSON);
            else
                NumbersList = new List<FizzbuzzApp>();

            FizzBuzz.CheckDisivibility();
            NumbersList.Add(FizzBuzz);

            HttpContext.Session.SetString("NumberListSession", JsonConvert.SerializeObject(NumbersList));           
            return Page();
        }
    }
}

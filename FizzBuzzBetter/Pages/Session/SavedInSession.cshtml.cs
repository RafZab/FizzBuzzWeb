using System.Collections.Generic;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;



namespace FizzBuzzBetter.Pages.Session
{
    public class SavedInSessionModel : PageModel
    {
        public List<Fizzbuzz> NumberList { get; set; }

        public void OnGet()
        {
            var NumberListSessionJSON = HttpContext.Session.GetString("NumberListSession");
            if (NumberListSessionJSON != null)
                NumberList = JsonConvert.DeserializeObject<List<Fizzbuzz>>(NumberListSessionJSON);
            else
                NumberList = new List<Fizzbuzz>();

        }
    }
}


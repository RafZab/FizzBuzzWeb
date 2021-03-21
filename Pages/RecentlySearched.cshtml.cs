using FizzBuzz.Scripts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Pages
{
    public class PrivacyModel : PageModel
    {
        public List<FizzbuzzApp> NumberList { get; set; }

        public void OnGet()
        {
            var NumberListSessionJSON = HttpContext.Session.GetString("NumberListSession");
            if (NumberListSessionJSON != null)
                NumberList = JsonConvert.DeserializeObject<List<FizzbuzzApp>>(NumberListSessionJSON);
            else
                NumberList = new List<FizzbuzzApp>();

        }
    }
}

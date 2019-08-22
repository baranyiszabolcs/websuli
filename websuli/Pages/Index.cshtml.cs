using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace websuli.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Gyerek Neve")]
        public string gyereknev { get; set; }
        public const string SessionKeyName = "Gyereknev";
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Gyereknev")))
            {
                HttpContext.Session.SetString(SessionKeyName, "Anonym");
                HttpContext.Session.SetInt32("Feladatsor", 0);
            }

            var name = HttpContext.Session.GetString(SessionKeyName);
            var age = HttpContext.Session.GetInt32("Feladatsor");
        }

        public void OnPost()
        {
       
                HttpContext.Session.SetString(SessionKeyName, gyereknev);
                HttpContext.Session.SetInt32("Feladatsor", 0);
        

            var name = HttpContext.Session.GetString(SessionKeyName);
            var feladatsor = HttpContext.Session.GetInt32("Feladatsor");

        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMatek.Models;

namespace websuli.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public string PageMessage {get;set;}  // can be accessed through view data and as well as Model.


        [BindProperty]
        [Display(Name = "Gyerek Neve")]
        public string gyereknev { get; set; }

        public const string SessionKeyGyereknev = "Gyereknev";
        
        public string feladattipus { get; set; } 
        public int feladatszam { get; set; } 

        public string email { get; set; }   // non binded
        public List<SelectListItem> FeladatTipusok { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Osszeadas", Text = "Összeadás" },
            new SelectListItem { Value = "Szorzas", Text = "Szorzás" },
            new SelectListItem { Value = "Szorzas/Osztas", Text = "Szorzás / Osztás"  },
            new SelectListItem { Value = "Zarojeles", Text = "Zárójles kifejezéek"  },
        };
        public void OnGet()
        {
            PageMessage = "Titkos Üzenet";
            /// razor oldalon a session változó  @HttpContext.Session.GetInt32("FeladatTipus")
            feladattipus = "Zarojeles";  // default
            gyereknev = "Maya";
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Gyereknev")))
            {
                HttpContext.Session.SetString(SessionKeyGyereknev, "Anonym");
                HttpContext.Session.SetInt32("Feladatsor", 0);
                HttpContext.Session.SetString("FeladatTipus", feladattipus);
                HttpContext.Session.SetInt32("Feladatszam", 100);
                HttpContext.Session.SetInt32("Helyes",0);
                HttpContext.Session.SetInt32("Rossz",0);
            }
            

        }

        public void OnPost()
        {

            if(gyereknev!="")
                HttpContext.Session.SetString(SessionKeyGyereknev, gyereknev);
         
            HttpContext.Session.SetInt32("Feladatszam", feladatszam);
            HttpContext.Session.SetString("FeladatTipus", feladattipus);

            RedirectToPage("./Matek");
        }

        public async void OnPostMatekSetupAsync()
        {
            PageMessage = "MateK Setup : " + email + "  /   " + feladattipus+"   gy:   " +gyereknev;
        }

        public void OnPostMatekSetupParam(string email)
        {
            var email2 = Request.Form["email"];
            PageMessage = "MateK Setup : "+email + "  /   " +email2;
        }


    }
}

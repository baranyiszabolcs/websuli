using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMatek.Models;

namespace websuli.Pages
{
    public class MatekModel : PageModel
    {
        public string feladattipus { get; set; }
        public Feladat feladvany { get; set; }
        public string feladvanyTxt { get; set; }
        public int valasz { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("FeladatTipus")))
                feladattipus = "Szorzas";
            else
                feladattipus = HttpContext.Session.GetString("FeladatTipus");

           // feladvany = Feladatsor.CreateFeladat(feladattipus); 
        }

        public void OnPost()
        {
            var fl = feladattipus;
        }

        public IActionResult OnPostMatekFeladat()
        {
            feladvany.Evaluate(valasz);
            return Page();
        }
    }
}
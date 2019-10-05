using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;

namespace websuli.Pages
{
    public class Feladatsor
    {
        [Display(Name ="Feadatsornev", Prompt ="Feladatsor Neve:")]
        string sornev { get; set; }
        int fealdatszam { get; set; }
    }
    ///  [BindProperties]   ezzel miden property kötve van
    public class testpageModel : PageModel
    {

        [BindProperty]
        public Feladatsor fsor { get; set; }
        [Display(Name = "Üzenet", Prompt = "Üzenet Prompt:")]
        [BindProperty]
        public string MessageLabel { get; set; }
        public string nonbindignev { get; set; }
        [BindProperty]
        public string bindingnev { get; set; }
        [ViewData]
        public string viewdatanev { get; set; }

        public string paramnev { get; set; }

        public string feladattipus { get; set; }

        public List<SelectListItem> FeladatTipusok { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Osszeadas", Text = "Összeadás" },
            new SelectListItem { Value = "Szorzas", Text = "Szorzás" },
            new SelectListItem { Value = "Szorzas/Osztas", Text = "Szorzás / Osztás"  },
            new SelectListItem { Value = "Zarojeles", Text = "Zárójeles kifejezések"  },
        };

        public void OnGet()
        {
            ViewData["Title"] = "Oldalcim";
            feladattipus = "szorzas";
        }

        public async void OnPostBactionAsync()
        {
            nonbindignev = bindingnev;
        }

        public  void OnPostMasikForm()
        {
            nonbindignev = feladattipus;
        }

        public void OnPostMasikFormWithParam(int buttonid)
        {
            nonbindignev = buttonid.ToString();
        }
    }
}
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
using websuli.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;

namespace websuli.Pages
{

    ///  [BindProperties]   ezzel miden property kötve van
    public class testpageModel : PageModel
    {

        [BindProperty]
        public Feladatsor fsor { get; set; } = new Feladatsor();
        [Display(Name = "Üzenet", Prompt = "Üzenet Prompt:")]
        [BindProperty]
        public string MessageLabel { get; set; }
        public string nonbindignev { get; set; }
        [BindProperty]
        public string bindingnev { get; set; }
        [ViewData]
        public string viewdatanev { get; set; }
        [BindProperty]
        public int sorszam { get; set; }
        [BindProperty]
        public int eredmenypct { get; set; }
        public string feladattipus { get; set; }

        private readonly IMemoryCache _cache;
        public testpageModel(IMemoryCache cache)
        {
            _cache = cache;
            Feladatsor lfsor;
            bool vanmarilyen = _cache.TryGetValue("0", out lfsor);
            fsor.kiadasDatum = DateTime.Now;
            // put the object into cache
            _cache.Set<Feladatsor>("0", fsor);

        }
        public void OnGet()
        {
            ViewData["Title"] = "Oldalcim";

           feladattipus = HttpContext.Session.GetString("FeladatTipus");
        }

        public async void OnPost()
        {
            nonbindignev = bindingnev;
            HttpContext.Session.SetInt32("Feladatszam", sorszam);
            HttpContext.Session.SetString("FeladatTipus", "szorzas");
            var srsz = Request.Form["sorszam"];  // form input tag neve...
        }

        // Az input   name="email"  értéke bemappelődik  és ez edősebb mint a route...
        public void OnPostMatekSetupParam(string email)
        {
            var email2 = Request.Form["email"];
            MessageLabel = "MateK Setup : " + email + "  /   " + email2;
        }

        public void OnPostMatekAction(string pstr)
        {
            var lsorszam = Request.Form["sorszam"];
            MessageLabel = "MateK Setup : {lsorszam}" +   pstr ;
        }

        public void OnPostBaction()
        {
            
            string fsorid = fsor.FeladatsorID.ToString();

            var origentry = _cache.Get<Feladatsor>("0");
            var cacheEntry = fsor;
            cacheEntry.kiadasDatum = DateTime.Now;
            _cache.Set<Feladatsor>(fsorid, cacheEntry);


            var myEntry = _cache.Get<Feladatsor>(fsorid);
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
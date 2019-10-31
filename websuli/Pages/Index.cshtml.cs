using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using websuli.Model;

namespace websuli.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public string PageMessage {get;set;}  // can be accessed through view data and as well as Model.
        [BindProperty]
        public Feladatsor fsor { get; set; } = new Feladatsor();
   

        public string email { get; set; }   // non binded
        // on way
        public List<SelectListItem> FeladatTipusok { get; } = FealdatsorLOV.FeladatTipusLista;


        private readonly IMemoryCache _cache;
        public IndexModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void OnGet()
        {
            fsor = new Feladatsor();
        }

        public void OnPost()
        {        
            HttpContext.Session.SetString("FeladatTipus", "szorszas");       
        }

        public async Task<IActionResult> OnPostMatekAsync()
        {// put the object into cache
             _cache.Set<Feladatsor>(fsor.id, fsor);
            return RedirectToPage("./Matek",new {id=fsor.id });
        }



    }
}

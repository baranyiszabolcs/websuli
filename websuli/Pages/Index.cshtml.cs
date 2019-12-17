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

        private IHttpContextAccessor _accessor;

        [ViewData]
        public string PageMessage {get;set;}  // can be accessed through view data and as well as Model.
        [BindProperty]
        public Feladatsor fsor { get; set; } = new Feladatsor();
   

        public string email { get; set; }   // non binded
        // on way
        public List<SelectListItem> FeladatTipusok { get; } = FealdatsorLOV.FeladatTipusLista;


        private readonly IMemoryCache _cache;
        public IndexModel(IMemoryCache cache, IHttpContextAccessor accessor)
        {
            _cache = cache;
            _accessor = accessor;
        }
        public void OnGet()
        {
            fsor = new Feladatsor();
            fsor.ipcim = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

        }

        public void OnPost()
        {        
            HttpContext.Session.SetString("FeladatTipus", fsor.feladatTipus);       
        }

        public RedirectToPageResult OnPostMatek()
        {// put the object into cache
            fsor.sornev = fsor.gyerek +"_"+ DateTime.Now.ToString();
            fsor.ipcim = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _cache.Set<Feladatsor>(fsor.FeladatsorID, fsor);
            HttpContext.Session.SetString("FeladatTipus", fsor.feladatTipus);
            return RedirectToPage("./Matek",new {id=fsor.FeladatsorID });
        }



    }
}

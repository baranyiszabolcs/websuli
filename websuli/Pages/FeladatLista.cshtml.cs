using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using websuli.Model;

namespace websuli.Pages
{
    public class FeladatListaModel : PageModel
    {
        //[BindProperty]
        //public string FeladatsorId { get; set; }
        [BindProperty]
        public Feladatsor fsor { get; set; }

        private readonly IMemoryCache _cache;
        public FeladatListaModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void OnGet(string feladatsorid)
        {
            Guid lguid; 
                //= HttpContext.Session.GetString("Id");
            //if (FeladatsorId != "")
                lguid = Guid.Parse(feladatsorid);
            fsor = _cache.Get<Feladatsor>(lguid);
        }
    }
}
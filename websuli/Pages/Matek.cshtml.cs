using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using websuli.Model;

namespace websuli.Pages
{
    public class MatekModel : PageModel
    {

        [BindProperty]
        public string valasz { get; set; }
        public Guid FeladatsorId { get; set; }
        [BindProperty]
        public string feladvanyTxt { get; set; }
        [BindProperty]
        public int hatravan { get; set; }
        [BindProperty]
        public DateTime startTime { get; set; }
        public string eredmenyTxt { get; set; }
        public Feladatsor fsor { get; set; }
        public string feladattipus { get; set; }
        public Feladat feladvany { get; set; }


        private readonly IMemoryCache _cache;
        public MatekModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public IActionResult OnGet(Guid id)
        {
            HttpContext.Session.SetString("feladvanyTxt", "");
            FeladatsorId = id;
            if (id == Guid.Empty)
            {
                FeladatsorId = Guid.NewGuid();
                fsor = new Feladatsor();
                fsor.feladatTipus = HttpContext.Session.GetString("FeladatTipus");
                _cache.Set<Feladatsor>(FeladatsorId, fsor);
                HttpContext.Session.SetString("Id", FeladatsorId.ToString());
            }
            else
            {
                fsor = _cache.Get<Feladatsor>(FeladatsorId);
                HttpContext.Session.SetString("Id", FeladatsorId.ToString());
            }

            feladvany = Feladatsor.GenerateFeladat(fsor.feladatTipus);
            feladvany.FealadatsorID = fsor.FeladatsorID;
            feladvanyTxt = feladvany.Generate();
            fsor.AddFeladatToList(feladvany);
            startTime = DateTime.Now;
            hatravan = fsor.feladatszam - fsor.cnt;
            return Page();
        }



        public IActionResult OnPostMatekFeladat()
        {

            string lguid = HttpContext.Session.GetString("Id");
            if (lguid != null)
                FeladatsorId = Guid.Parse(lguid);

            fsor = _cache.Get<Feladatsor>(FeladatsorId);
            feladvany = fsor.feladatlista[fsor.cnt];
            if (valasz == null)
                valasz = "0";

            valasz = valasz.ToUpper().Trim();
            eredmenyTxt = feladvany.Evaluate(valasz);
            feladvanyTxt = feladvany.feladatText;   /// ez van sessionben is
            feladvany.ValaszidoSec = (int)DateTime.Now.Subtract(startTime).TotalSeconds;
            fsor.UpdateFeladat( feladvany);
            hatravan = fsor.feladatszam - fsor.cnt;
            if (hatravan == 0)
            {
                fsor.cnt = fsor.cnt - 1;
                return RedirectToPage("./FeladatLista", new { feladatsorid = lguid });
            }
            feladvany = Feladatsor.GenerateFeladat(fsor.feladatTipus);
            feladvany.FealadatsorID = fsor.FeladatsorID;
            feladvanyTxt = feladvany.Generate();
            valasz = "";
   
            feladvany.Gyerekvalasz = "";
            fsor.AddFeladatToList(feladvany);
            startTime = DateTime.Now;  
            ModelState.Clear();
   
           
            return Page();
        }
    }
}
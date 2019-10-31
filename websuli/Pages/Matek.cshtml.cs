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
    public class MatekModel : PageModel
    {

        [BindProperty]
        public string valasz { get; set; }
        [BindProperty]
        public Guid Id { get; set; }
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
            
            if (id == Guid.Empty)
            { Id = Guid.NewGuid();
                fsor = new Feladatsor();
                _cache.Set<Feladatsor>(Id, fsor);
            }
            else
                fsor = _cache.Get<Feladatsor>(id);

            feladvany = Feladatsor.GenerateFeladat(fsor.feladatTipus);
            feladvanyTxt = feladvany.Generate();
            fsor.AddFeladatToList(feladvany);
            startTime = DateTime.Now;
            hatravan = fsor.feladatszam - fsor.cnt;
            return Page();
        }



        public IActionResult OnPostMatekFeladat()
        {
            
            fsor = _cache.Get<Feladatsor>(Id);
            feladvany = fsor.feladatlista[fsor.cnt];
            eredmenyTxt = feladvany.Evaluate(valasz);
            feladvany.ValaszidoSec = (int)DateTime.Now.Subtract(startTime).TotalSeconds;
            fsor.UpdateFeladat( feladvany);
            if (eredmenyTxt=="OK")
            {
                // ez csak ha vegyes feladatok vannak
                //feladvany = Feladatsor.GenerateFeladat(fsor.feladatTipus);
                feladvanyTxt = feladvany.Generate();
            }
            fsor.AddFeladatToList(feladvany);
            startTime = DateTime.Now;

            hatravan = fsor.feladatszam - fsor.cnt;
            ModelState.Clear();
            return Page();
        }
    }
}
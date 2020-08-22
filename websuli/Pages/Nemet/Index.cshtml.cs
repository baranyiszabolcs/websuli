using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using websuli.Model;
using websuli.Models;

namespace websuli.Pages.Nemet
{
    public class IndexModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public IndexModel(websuli.Models.websuliContext context)
        {
            _context = context;
        }

        public IList<NemetSzo> NemetSzo { get;set; }

        public async Task OnGetAsync()
        {
            NemetSzo = await _context.NemetSzos.ToListAsync();
        }
    }
}

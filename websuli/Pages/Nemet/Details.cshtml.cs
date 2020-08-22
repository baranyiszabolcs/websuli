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
    public class DetailsModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public DetailsModel(websuli.Models.websuliContext context)
        {
            _context = context;
        }

        public NemetSzo NemetSzo { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NemetSzo = await _context.NemetSzos.FirstOrDefaultAsync(m => m.ID == id);

            if (NemetSzo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

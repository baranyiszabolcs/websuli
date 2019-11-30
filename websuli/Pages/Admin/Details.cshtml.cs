using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using websuli.Model;
using websuli.Models;

namespace websuli
{
    public class DetailsModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public DetailsModel(websuli.Models.websuliContext context)
        {
            _context = context;
        }

        public Feladatsor Feladatsor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feladatsor = await _context.Feladatsor.FirstOrDefaultAsync(m => m.FeladatsorID == id);

            if (Feladatsor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

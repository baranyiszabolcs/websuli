using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using websuli.Model;
using websuli.Models;

namespace websuli
{
    public class EditModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public EditModel(websuli.Models.websuliContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Feladatsor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeladatsorExists(Feladatsor.FeladatsorID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FeladatsorExists(Guid id)
        {
            return _context.Feladatsor.Any(e => e.FeladatsorID == id);
        }
    }
}

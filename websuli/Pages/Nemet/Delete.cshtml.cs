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
    public class DeleteModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public DeleteModel(websuli.Models.websuliContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NemetSzo NemetSzo { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {

            NemetSzo = await _context.NemetSzos.FirstOrDefaultAsync(m => m.ID == id);

            if (NemetSzo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {

            NemetSzo = await _context.NemetSzos.FindAsync(id);

            if (NemetSzo != null)
            {
                _context.NemetSzos.Remove(NemetSzo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

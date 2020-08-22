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

namespace websuli.Pages.Nemet
{
    public class EditModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public EditModel(websuli.Models.websuliContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NemetSzo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NemetSzoExists(NemetSzo.Nemet))
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

        private bool NemetSzoExists(string id)
        {
            return _context.NemetSzos.Any(e => e.Nemet == id);
        }
    }
}

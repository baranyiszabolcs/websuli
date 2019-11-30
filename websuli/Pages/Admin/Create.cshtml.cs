using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using websuli.Model;
using websuli.Models;

namespace websuli
{
    public class CreateModel : PageModel
    {
        private readonly websuli.Models.websuliContext _context;

        public CreateModel(websuli.Models.websuliContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Feladatsor Feladatsor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Feladatsor.Add(Feladatsor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
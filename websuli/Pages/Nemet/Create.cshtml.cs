using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using websuli.Model;
using websuli.Models;

namespace websuli.Pages.Nemet
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
            NemetSzoLista =  _context.NemetSzos.ToList();
            Msg = "";
            return Page();
        }

        [BindProperty]
        public NemetSzo NemetSzo { get; set; }
        public IList<NemetSzo> NemetSzoLista { get; set; }
        public string Msg{ get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NemetSzos.Add(NemetSzo);
            try
            {
                Msg = "";
                await _context.SaveChangesAsync();//C:\Users\szbarany\source\websuli\websuli\Pages\Nemet\Create.cshtml.cs
            } catch (Exception ex)
            {
                Msg = @"Már van ilyen szó";
                NemetSzoLista = _context.NemetSzos.ToList();

                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}

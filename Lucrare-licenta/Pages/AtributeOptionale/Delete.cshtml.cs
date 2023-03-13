using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.AtributeOptionale
{
    public class DeleteModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public DeleteModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AtributOptional AtributOptional { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AtributOptional == null)
            {
                return NotFound();
            }

            var atributoptional = await _context.AtributOptional.FirstOrDefaultAsync(m => m.ID == id);

            if (atributoptional == null)
            {
                return NotFound();
            }
            else 
            {
                AtributOptional = atributoptional;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AtributOptional == null)
            {
                return NotFound();
            }
            var atributoptional = await _context.AtributOptional.FindAsync(id);

            if (atributoptional != null)
            {
                AtributOptional = atributoptional;
                _context.AtributOptional.Remove(AtributOptional);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.CategoriiVehicule
{
    public class DeleteModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public DeleteModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CategorieVehicul CategorieVehicul { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CategorieVehicul == null)
            {
                return NotFound();
            }

            var categorievehicul = await _context.CategorieVehicul.FirstOrDefaultAsync(m => m.ID == id);

            if (categorievehicul == null)
            {
                return NotFound();
            }
            else 
            {
                CategorieVehicul = categorievehicul;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CategorieVehicul == null)
            {
                return NotFound();
            }
            var categorievehicul = await _context.CategorieVehicul.FindAsync(id);

            if (categorievehicul != null)
            {
                CategorieVehicul = categorievehicul;
                _context.CategorieVehicul.Remove(CategorieVehicul);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

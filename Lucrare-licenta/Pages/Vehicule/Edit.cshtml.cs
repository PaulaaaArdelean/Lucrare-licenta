using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.Vehicule
{
    public class EditModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public EditModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicul Vehicul { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vehicul == null)
            {
                return NotFound();
            }

            var vehicul =  await _context.Vehicul.FirstOrDefaultAsync(m => m.ID == id);
            if (vehicul == null)
            {
                return NotFound();
            }
            Vehicul = vehicul;
           ViewData["CategorieVehiculID"] = new SelectList(_context.Set<CategorieVehicul>(), "ID", "CategoriaVehicul");
           ViewData["TipCombustibilID"] = new SelectList(_context.Set<TipCombustibil>(), "ID", "TipulCombustibil");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vehicul).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculExists(Vehicul.ID))
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

        private bool VehiculExists(int id)
        {
          return _context.Vehicul.Any(e => e.ID == id);
        }
    }
}

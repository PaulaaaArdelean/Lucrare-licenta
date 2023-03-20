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

namespace Lucrare_licenta.Pages.Localitati
{
    public class EditModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public EditModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Localitate Localitate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Localitate == null)
            {
                return NotFound();
            }

            var localitate =  await _context.Localitate.FirstOrDefaultAsync(m => m.ID == id);
            if (localitate == null)
            {
                return NotFound();
            }
            Localitate = localitate;
           ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "Judetul");
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

            _context.Attach(Localitate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalitateExists(Localitate.ID))
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

        private bool LocalitateExists(int id)
        {
          return _context.Localitate.Any(e => e.ID == id);
        }
    }
}

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

namespace Lucrare_licenta.Pages.PersoaneFizice
{
    public class EditModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public EditModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersoanaFizica PersoanaFizica { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersoanaFizica == null)
            {
                return NotFound();
            }

            var persoanafizica =  await _context.PersoanaFizica.FirstOrDefaultAsync(m => m.ID == id);
            if (persoanafizica == null)
            {
                return NotFound();
            }
            PersoanaFizica = persoanafizica;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeIntreg");
            //ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "Judetul");
            //ViewData["LocalitateID"] = new SelectList(_context.Localitate, "ID", "Localitatea");
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

            _context.Attach(PersoanaFizica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoanaFizicaExists(PersoanaFizica.ID))
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

        private bool PersoanaFizicaExists(int id)
        {
          return _context.PersoanaFizica.Any(e => e.ID == id);
        }
    }
}

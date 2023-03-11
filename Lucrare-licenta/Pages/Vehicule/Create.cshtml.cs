using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.Vehicule
{
    public class CreateModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public CreateModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategorieVehiculID"] = new SelectList(_context.Set<CategorieVehicul>(), "ID", "CategoriaVehicul");
        ViewData["TipCombustibilID"] = new SelectList(_context.Set<TipCombustibil>(), "ID", "TipulCombustibil");
            return Page();
        }

        [BindProperty]
        public Vehicul Vehicul { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vehicul.Add(Vehicul);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

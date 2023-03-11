using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.Oferte
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
        ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "ID");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
        ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Oferta Oferta { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Oferta.Add(Oferta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.Localitati
{
    public class DetailsModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public DetailsModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

      public Localitate Localitate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Localitate == null)
            {
                return NotFound();
            }

            var localitate = await _context.Localitate.FirstOrDefaultAsync(m => m.ID == id);
            if (localitate == null)
            {
                return NotFound();
            }
            else 
            {
                Localitate = localitate;
            }
            return Page();
        }
    }
}

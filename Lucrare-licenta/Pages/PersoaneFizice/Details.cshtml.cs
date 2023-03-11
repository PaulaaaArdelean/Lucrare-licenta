using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.PersoaneFizice
{
    public class DetailsModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public DetailsModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

      public PersoanaFizica PersoanaFizica { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersoanaFizica == null)
            {
                return NotFound();
            }

            var persoanafizica = await _context.PersoanaFizica.FirstOrDefaultAsync(m => m.ID == id);
            if (persoanafizica == null)
            {
                return NotFound();
            }
            else 
            {
                PersoanaFizica = persoanafizica;
            }
            return Page();
        }
    }
}

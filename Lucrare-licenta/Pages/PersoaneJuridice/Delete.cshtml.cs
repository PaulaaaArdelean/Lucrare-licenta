﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.PersoaneJuridice
{
    public class DeleteModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public DeleteModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PersoanaJuridica PersoanaJuridica { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersoanaJuridica == null)
            {
                return NotFound();
            }

            var persoanajuridica = await _context.PersoanaJuridica.FirstOrDefaultAsync(m => m.ID == id);

            if (persoanajuridica == null)
            {
                return NotFound();
            }
            else 
            {
                PersoanaJuridica = persoanajuridica;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PersoanaJuridica == null)
            {
                return NotFound();
            }
            var persoanajuridica = await _context.PersoanaJuridica.FindAsync(id);

            if (persoanajuridica != null)
            {
                PersoanaJuridica = persoanajuridica;
                _context.PersoanaJuridica.Remove(PersoanaJuridica);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.TipuriSocietate
{
    public class DeleteModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public DeleteModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipSocietate TipSocietate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipSocietate == null)
            {
                return NotFound();
            }

            var tipsocietate = await _context.TipSocietate.FirstOrDefaultAsync(m => m.ID == id);

            if (tipsocietate == null)
            {
                return NotFound();
            }
            else 
            {
                TipSocietate = tipsocietate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipSocietate == null)
            {
                return NotFound();
            }
            var tipsocietate = await _context.TipSocietate.FindAsync(id);

            if (tipsocietate != null)
            {
                TipSocietate = tipsocietate;
                _context.TipSocietate.Remove(TipSocietate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.Vehicule
{
    public class IndexModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public IndexModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IList<Vehicul> Vehicul { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vehicul != null)
            {
                Vehicul = await _context.Vehicul
                .Include(v => v.CategorieVehicul)
                .Include(v => v.TipCombustibil).ToListAsync();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Pages.Oferte
{
    public class IndexModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public IndexModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IList<Oferta> Oferta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Oferta != null)
            {
                Oferta = await _context.Oferta
                .Include(o => o.CategorieVehicul)
                .Include(o => o.Client)
                .Include(o => o.TipCombustibil).ToListAsync();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Lucrare_licenta.Pages.Clienti
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public IndexModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client
                .Include(c => c.TipSocietate)
                .Include(c => c.TipAsigurat)
                .Include(c => c.Localitate)
                .Include(c => c.Judet)
                .ToListAsync();
            }
        }
    }
}

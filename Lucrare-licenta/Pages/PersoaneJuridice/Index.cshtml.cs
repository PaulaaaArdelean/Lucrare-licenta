using System;
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

namespace Lucrare_licenta.Pages.PersoaneJuridice
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public IndexModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IList<PersoanaJuridica> PersoanaJuridica { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PersoanaJuridica != null)
            {
                PersoanaJuridica = await _context.PersoanaJuridica
                .Include(p => p.Client)
                .ThenInclude(p => p.TipSocietate)
                .Include(p => p.Client)
                .Include(c => c.Judet)
                 .Include(p => p.Client)
                .Include(c => c.Localitate)
                .ToListAsync();
            }
        }
    }
}

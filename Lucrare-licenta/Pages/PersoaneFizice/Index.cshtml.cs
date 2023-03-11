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
    public class IndexModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public IndexModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IList<PersoanaFizica> PersoanaFizica { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PersoanaFizica != null)
            {
                PersoanaFizica = await _context.PersoanaFizica
                .Include(p => p.Client).ToListAsync();
            }
        }
    }
}

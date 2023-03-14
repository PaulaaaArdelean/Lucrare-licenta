using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Lucrare_licenta.Pages.Oferte
{
    public class IndexModel : PageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;

        public IndexModel(Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _context = context;
        }

        public IList<Oferta> Oferta { get; set; } = default!;
        public OfertaData OfertaD { get; set; }
        public int OfertaID { get; set; }
        public int OptionalID { get; set; }
        public String CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? optionalID, string searchString)
        {


            var anFabricatie = _context.Oferta.Select(x => new {x.ID, anulFabricatiei = x.AnFabricatie});
            var capacitateCilindrica = _context.Oferta.Select(x => new { x.ID, capacitateaCilindrica = x.CapacitateCilindrica });


                //var pret = anFabricatie * 0.2 + capacitateCilindrica * 0.8 ;

            CurrentFilter = searchString;

            OfertaD = new OfertaData();

            OfertaD.Oferte = await _context.Oferta
            .Include(b => b.Client)
            .Include(b => b.TipCombustibil)
            .Include(b => b.CategorieVehicul)

            .Include(b => b.AtributeOptionaleOferta)
            .ThenInclude(b => b.AtributOptional)
            .AsNoTracking()
            // .OrderBy(b => b.N)
            .ToListAsync();




            if (!String.IsNullOrEmpty(searchString))
            {
                OfertaD.Oferte = OfertaD.Oferte.Where(s => s.Client.NumeClientFirma.Contains(searchString)

               || s.NrInmatriculare.Contains(searchString)
               || s.NumarIdentificare.Contains(searchString)
               || s.Marca.Contains(searchString)
               || s.CategorieVehicul.CategoriaVehicul.Contains(searchString)
               ||s.TipCombustibil.TipulCombustibil.Contains(searchString)
               || s.SerieCIV.Contains(searchString)
               || s.AnFabricatie.Contains(searchString)
               || s.Model.Contains(searchString)
               || s.NumarIdentificare.Contains(searchString));


            }
            

                if (id != null)
            {
                OfertaID = id.Value;
                Oferta oferta = OfertaD.Oferte
                .Where(i => i.ID == id.Value).Single();
                OfertaD.AtributeOptionale = oferta.AtributeOptionaleOferta.Select(s => s.AtributOptional);
            }

        
            }
        }
    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lucrare_licenta.Models;

namespace Lucrare_licenta.Data
{
    public class Lucrare_licentaContext : DbContext
    {
        public Lucrare_licentaContext (DbContextOptions<Lucrare_licentaContext> options)
            : base(options)
        {
        }

        public DbSet<Lucrare_licenta.Models.Vehicul> Vehicul { get; set; } = default!;

        public DbSet<Lucrare_licenta.Models.CategorieVehicul> CategorieVehicul { get; set; }

        public DbSet<Lucrare_licenta.Models.TipCombustibil> TipCombustibil { get; set; }

        public DbSet<Lucrare_licenta.Models.Client> Client { get; set; }

        public DbSet<Lucrare_licenta.Models.TipSocietate> TipSocietate { get; set; }

        public DbSet<Lucrare_licenta.Models.PersoanaFizica> PersoanaFizica { get; set; }

        public DbSet<Lucrare_licenta.Models.PersoanaJuridica> PersoanaJuridica { get; set; }

        public DbSet<Lucrare_licenta.Models.Oferta> Oferta { get; set; }

        public DbSet<Lucrare_licenta.Models.AtributOptional> AtributOptional { get; set; }
        public DbSet<Lucrare_licenta.Models.TipAsigurat> TipAsigurat { get; set; }
        public DbSet<Lucrare_licenta.Models.Judet> Judet { get; set; }
        public DbSet<Lucrare_licenta.Models.Localitate> Localitate { get; set; }

    }
}

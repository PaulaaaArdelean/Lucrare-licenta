using System.ComponentModel.DataAnnotations;

namespace Lucrare_licenta.Models
{
    public class CategorieVehicul
    {
        public int ID { get; set; }
        [Display(Name ="Categorie")]
        public string CategoriaVehicul { get; set; }
        public ICollection<Vehicul>? Vehicule { get; set; }
        public ICollection<Oferta>? Oferte { get; set; }

    }
}

namespace Lucrare_licenta.Models
{
    public class CategorieVehicul
    {
        public int ID { get; set; }
        public string CategoriaVehicul { get; set; }
        public ICollection<Vehicul>? Vehicule { get; set; }
    }
}

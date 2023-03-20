namespace Lucrare_licenta.Models
{
    public class Judet
    {
        public int ID { get; set; }
        public string Judetul { get; set; }
        public ICollection<Localitate>? Localitati { get; set; }
        public ICollection<Client>? Clienti { get; set; }
        public ICollection<PersoanaFizica>? PersoaneFizice { get; set; }
        public ICollection<PersoanaJuridica>? PersoaneJuridice { get; set; }
    }
}

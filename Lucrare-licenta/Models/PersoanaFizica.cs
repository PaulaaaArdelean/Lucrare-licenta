namespace Lucrare_licenta.Models
{
    public class PersoanaFizica
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
    }
}

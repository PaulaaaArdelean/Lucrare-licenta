namespace Lucrare_licenta.Models
{
    public class PersoanaFizica
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
       public Client? Client { get; set; }
        public int? JudetID { get; set; }
       public Judet? Judet { get; set; }

        public int? LocalitateID { get; set; }
        public Localitate? Localitate { get; set; }
    }
}

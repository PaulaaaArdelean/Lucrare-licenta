namespace Lucrare_licenta.Models
{
    public class AtributOptional
    {
        public int ID { get; set; }
        public string AtributulOptional { get; set; }
        public ICollection<AtributOptionalOferta>? AtributeOptionaleOferta { get; set; }
    }
}

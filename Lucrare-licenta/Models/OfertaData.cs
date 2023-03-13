namespace Lucrare_licenta.Models
{
    public class OfertaData
    {public IEnumerable<Oferta> Oferte { get; set; }
        public IEnumerable<AtributOptional> AtributeOptionale { get; set; }
        public IEnumerable<AtributOptionalOferta> AtributeOptionaleOferta { get; set; }
    }
}

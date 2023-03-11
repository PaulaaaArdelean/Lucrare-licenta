using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lucrare_licenta.Models
{
    public class Vehicul
    {
        public int ID { get; set; }


        public int? OfertaID { get; set; }
        public Oferta? Oferte { get; set; }


    }
}

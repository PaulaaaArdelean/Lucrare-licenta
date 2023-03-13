using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lucrare_licenta.Models
{
    public class AtributOptionalOferta
    {
        public int ID { get; set; }
        public int OfertaID { get; set; }
        public Oferta Oferta { get; set; }
        public int AtributOptionalID { get; set; }
        [Display(Name = "Optional")]

        public AtributOptional AtributOptional { get; set; }
    }
}

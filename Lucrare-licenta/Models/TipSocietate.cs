using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lucrare_licenta.Models
{
    public class TipSocietate
    {
        public int ID { get; set; }
        [Display(Name = "Tipul de societate")]
        [RegularExpression(@"(SRL|SA|PFA|SA|IF|II|SCS|SCA|--)$", ErrorMessage = "Tipul de societate poate fi SRL-Societate cu Raspundere Limitata, SA-Societate pe Actiuni sau PFA-Persoana Fizica Autorizata")]

        public string TipulSocietate { get; set; }
        public ICollection<Client>? Clienti { get; set; }
        public ICollection<PersoanaJuridica>? PersoaneJuridice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lucrare_licenta.Models
{
    public class TipAsigurat
    {
        public int ID { get; set; }

        [Display(Name = "Tipul asiguratului")]
        [RegularExpression(@"(PF|PJ)$", ErrorMessage = "Tipul de asigurat poate fi PFA, SA, SRL,SCA, SCS, II, IF")]

        public string TipulAsigurat { get; set; }
        public ICollection<Client>? Clienti { get; set; }
    }
}

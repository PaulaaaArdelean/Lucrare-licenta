using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lucrare_licenta.Models
{
    public class Vehicul
    {
        public int ID { get; set; }
        [Display(Name = "Numarul de identificare")]
        [RegularExpression(@"[A-HJ-NP-PR-Z0-9]{17}$", ErrorMessage = "Numarul de identificare este format din 17 caractere – cifre și litere, excluzând literele I, O și Q.")]

        public string NumarIdentificare { get; set; }
        [Display(Name = "Numarul de inmatriculare")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{2}[A-Z]{3}$", ErrorMessage = "Numarul de inmatriculare are forma AA00AAA")]
        public string NrInmatriculare { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        [Display(Name = "Anul fabricatiei")]
        [RegularExpression(@"([0-9]{4})", ErrorMessage = "Campul {0} trebuie sa fie de forma 2001 si nu poate contine litere sau caractere speciale. {0} poate fi minim 1995 si maxim 2024")]
        [Range(1995, 2023)]

        public string AnFabricatie { get; set; }
        [Display(Name = "Capacitate cilindrica")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Capacitatea cilindrica este formata din 3 sau 4 cifre")]
        public string CapacitateCilindrica { get; set; }
        [Display(Name = "Serie CIV")]
        [RegularExpression(@"^\(?([A-Z]{1})\)?([0-9]{6})$", ErrorMessage = "Seria CIV trebuie sa aiba forma A123456")]

        public string SerieCIV { get; set; }
        [Display(Name = "Numar de locuri")]
        [RegularExpression(@"^[1-9]$", ErrorMessage = "Numarul de locuri trebuie sa fie scris in cifre")]
        public string NrLocuri { get; set; }
        [RegularExpression(@"^[0-9]{3,5}$", ErrorMessage = "Masa maxima este formata din 3, 4 sau 5 cifre")]
        [Display(Name = "Masa maxima")]

        public string MasaMaxima { get; set; }
        [RegularExpression(@"^[0-9]{2,4}$", ErrorMessage = "Puterea trebuie sa fie scrisa din 2, 3 sau 4 cifre")]
        public string Putere { get; set; }

        public int? CategorieVehiculID { get; set; }
        public CategorieVehicul? CategorieVehicul { get; set; }
        public int? TipCombustibilID { get; set; }
        [Display(Name = "Tipul de combustibil")]
        public TipCombustibil? TipCombustibil { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lucrare_licenta.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[1-8][0-9]{2}(0[1-9]|1[0-2])(0[1-9]|[1-2][0-9]|3[0-1])(0[1-9]|[1-4][0-9]|5[0-2])[0-9]{4}$", ErrorMessage = "Un CNP (Cod Numeric Personal) este un cod numeric din 13 cifre atribuit de Guvernul României fiecărui cetățean. Codul este formatat după cum urmează: prima cifră reprezintă sexul, a doua și a treia cifră reprezintă anul nașterii, a patra și a cincea cifră reprezintă luna nașterii, a șasea și a șaptea cifră reprezintă ziua nașterii, a opta cifră reprezintă regiunea nașterii, a noua cifră reprezintă județul de naștere, iar ultimele patru cifre reprezintă ordinea înregistrării.")]
        public string? CNP { get; set; }


        [Display(Name = "Numele")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string? NumeProprietar { get; set; }



        [Display(Name = "Prenumele")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string? PrenumeProprietar { get; set; }



        [Display(Name = "Numele si prenumele proprietarului")]
        public string? NumeIntreg
        {
            get
            {
                return NumeProprietar + " " + PrenumeProprietar;
            }
        }



        [Display(Name = "Serie CI")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Seria CI este formata din doua litere mari, care vin de regulă vin de mnemonicul județului (ex. IS-Iași ), dar nu este obligatoriu (ex. AS-Argeș)")]
        public string? SerieCI { get; set; }


        [Display(Name = "Numar CI")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Numarul cartii de identitate trebuie sa contina 6 cifre")]
        public string? NumarCI { get; set; }






        [RegularExpression("^[1-9][0-9]{7}$", ErrorMessage = "CUI-ul trebuie sa fie alcatuit din 8 cifre si nu poate incepe cu 0")]
        public string? CUI { get; set; }

        [Display(Name = "Tipul societatii")]
        public int? TipSocietateID { get; set; }
        public TipSocietate? TipSocietate { get; set; }

        [Display(Name = "Activitatea societatii")]
        public string? ActivitateSocietate { get; set; }

        [Display(Name = "Numele societatii")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Denumirea societatii trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string? NumeFirma { get; set; }


        [Display(Name = "Numele reprezentantului")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string? NumeReprezentantFirma { get; set; }


        [Display(Name = "Prenumele reprezentantului")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string? PrenumeReprezentantFirma { get; set; }

        [Display(Name = "Numele si prenumele reprezentantului firmei")]
        public string? NumeIntregReprezentant
        {
            get
            {
                return NumeReprezentantFirma + " " + PrenumeReprezentantFirma;
            }
        }






        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele judetului trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
        [StringLength(30, MinimumLength = 2)]

        public string Judet { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele localitatii trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
        [StringLength(30, MinimumLength = 2)]

        public string Localitate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele strazii trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
        [StringLength(30, MinimumLength = 2)]
        public string Strada { get; set; }


        public string Numar { get; set; }


        [Display(Name = "Codul postal")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Codul postal trebuie sa contina 6 cifre")]
        public string? CodPostal { get; set; }



        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,3}$", ErrorMessage = "Datele introduse de dumneavoastra nu am forma unui email.")]

        public string Email { get; set; }



        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string Telefon { get; set; }

    }
}

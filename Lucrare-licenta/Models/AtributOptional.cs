using System.ComponentModel.DataAnnotations;

namespace Lucrare_licenta.Models
{
    public class AtributOptional
    {
        public int ID { get; set; }
        [Display(Name = "Optional")]
        public string AtributulOptional { get; set; }
        public ICollection<AtributOptionalOferta>? AtributeOptionaleOferta { get; set; }
    }
}

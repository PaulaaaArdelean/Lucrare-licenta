using Lucrare_licenta.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lucrare_licenta.Models
{
    public class OferteOptionalPageModel : PageModel
    {
 
 public List<AssignedOptionalData> AssignedOptionalDataList;
        public void PopulateAssignedOptionalData(Lucrare_licentaContext context,
        Oferta oferta)
        {
            var allAttributes = context.AtributOptional;
            var atributeOferta = new HashSet<int>(
            oferta.AtributeOptionaleOferta.Select(c => c.AtributOptionalID)); //
            AssignedOptionalDataList = new List<AssignedOptionalData>();
            foreach (var cat in allAttributes)
            {
                AssignedOptionalDataList.Add(new AssignedOptionalData
                {
                    OptionalID = cat.ID,
                    AtributOptional = cat.AtributulOptional,
                    Assigned = atributeOferta.Contains(cat.ID)
                });
            }
        }
        public void UpdateAtributeOptionaleOferta(Lucrare_licentaContext context,
        string[] selectedAttributes, Oferta ofertaToUpdate)
        {
            if (selectedAttributes == null)
            {
                ofertaToUpdate.AtributeOptionaleOferta = new List<AtributOptionalOferta>();
                return;
            }
            var selectedAttributesHS = new HashSet<string>(selectedAttributes);
            var AtributeOptionaleOferta = new HashSet<int>
            (ofertaToUpdate.AtributeOptionaleOferta.Select(c => c.AtributOptional.ID));
            foreach (var cat in context.AtributOptional)
            {
                if (selectedAttributesHS.Contains(cat.ID.ToString()))
                {
                    if (!AtributeOptionaleOferta.Contains(cat.ID))
                    {
                        ofertaToUpdate.AtributeOptionaleOferta.Add(
                        new AtributOptionalOferta
                        {
                            OfertaID = ofertaToUpdate.ID,
                            AtributOptionalID = cat.ID
                        });
                    }
                }
                else
                {
                    if (AtributeOptionaleOferta.Contains(cat.ID))
                    {

                        AtributOptionalOferta courseToRemove
                        = ofertaToUpdate
                        .AtributeOptionaleOferta
                        .SingleOrDefault(i => i.AtributOptionalID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lucrare_licenta.Data;
using Lucrare_licenta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lucrare_licenta.Pages.Oferte
{
    public class CreateModel : OferteOptionalPageModel
    {
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public CreateModel(Lucrare_licenta.Data.Lucrare_licentaContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IActionResult OnGet()
        {
            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                .Where(c => c.Email == userName)
                .Select(x => new
                {
                    x.ID,
                    DetaliiClient = x.NumeIntreg + " " + x.NumeFirma
                });

            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient");
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");

            var oferta = new Oferta();
            oferta.AtributeOptionaleOferta = new List<AtributOptionalOferta>();
            PopulateAssignedOptionalData(_context, oferta);
            return Page();
        }

        [BindProperty]
        public Oferta Oferta { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedAttributes)
        {
            var newOferta = new Oferta();
            if (selectedAttributes != null)
            {
                newOferta.AtributeOptionaleOferta = new List<AtributOptionalOferta>();
                foreach (var cat in selectedAttributes)
                {
                    var catToAdd = new AtributOptionalOferta
                    {
                        AtributOptionalID = int.Parse(cat)
                    };
                    newOferta.AtributeOptionaleOferta.Add(catToAdd);
                }
            }
            Oferta.AtributeOptionaleOferta = newOferta.AtributeOptionaleOferta;
            _context.Oferta.Add(Oferta);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedOptionalData(_context, newOferta);
            return Page();
        }

    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Lucrare_licenta.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Lucrare_licenta.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly Lucrare_licenta.Data.Lucrare_licentaContext _context;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
           Lucrare_licenta.Data.Lucrare_licentaContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public Client Client { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>


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


            // [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele judetului trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
            //[StringLength(30, MinimumLength = 2)]
            //  [Required]
            [Display(Name ="Judetul")]
            public int JudetID { get; set; }
            public Judet? Judet { get; set; }

            [Display(Name = "Localitatea")]
            public int LocalitateID { get; set; }
            public Localitate? Localitate { get; set; }

            [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele strazii trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
            [StringLength(30, MinimumLength = 2)]
            [Required]

            public string Strada { get; set; }
            public string Numar { get; set; }


            [Display(Name = "Codul postal")]
            [RegularExpression("^[0-9]{6}$", ErrorMessage = "Codul postal trebuie sa contina 6 cifre")]
            public string? CodPostal { get; set; }

            [Required]
            [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
            public string Telefon { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await
           _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, Input.Email,
           CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Input.Email,
           CancellationToken.None);
            var result = await _userManager.CreateAsync(user,
           Input.Password);
            Client.Email = Input.Email;
            Client.CNP = Input.CNP;
            Client.NumeProprietar = Input.NumeProprietar;
            Client.PrenumeProprietar= Input.PrenumeProprietar;
            Client.SerieCI = Input.SerieCI;
            Client.NumarCI = Input.NumarCI;
            Client.CUI = Input.CUI;
            Client.TipSocietate = Input.TipSocietate;
            Client.ActivitateSocietate= Input.ActivitateSocietate;
            Client.NumeFirma = Input.NumeFirma;
            Client.NumeReprezentantFirma = Input.NumeReprezentantFirma;
            Client.PrenumeReprezentantFirma = Input.PrenumeReprezentantFirma;
            Client.Judet = Input.Judet;
            Client.Localitate = Input.Localitate;
            Client.Strada = Input.Strada;
            Client.Numar = Input.Numar;
            Client.CodPostal = Input.CodPostal;
            Client.Telefon = Input.Telefon;
            _context.Client.Add(Client);
            await _context.SaveChangesAsync();
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with  password.");
               
                var role = await _userManager.AddToRoleAsync(user, "User");
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await
               _userManager.GenerateEmailConfirmationTokenAsync(user);
                code =
               WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
               pageHandler: null,
               values: new
               {
                   area = "Identity",
                   userId = userId,
                   code = code,
                   returnUrl = returnUrl
               },
                protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(Input.Email, "Confirm  the email",
               
                $"Please confirm the account by <a href = '{HtmlEncoder.Default.Encode(callbackUrl)}' > clicking here </ a >.");
           


 if
(_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToPage("RegisterConfirmation", new
                    {
                        email = Input.Email,
                        returnUrl = returnUrl
                    });
                }
                else
                {
                    await _signInManager.SignInAsync(user,
                   isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,
                   error.Description);
                }
            }
            return Page();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}

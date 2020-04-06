using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using gestionpresence.Data;
using gestionpresence.Models;

namespace gestionpresence.Areas.Identity.Pages.Account
{
    
    
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager,
             ApplicationDbContext db
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }



        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Nom")]
            public string Nom { get; set; }

            [Required]
            [Display(Name = "Prénom")]
            public string Prenom { get; set; }

            [Required]
            [Display(Name = "Code RFID")]
            public string CodeRFID { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string RoleId { get; set; }

        }


        public List<SelectListItem> Options { get; set; }
        public async Task OnGetAsync(string returnUrl = null)
        {
            //zack
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.Prof))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Prof));
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Etud))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Etud));
            }



            Options = _db.Roles.Select(a =>
                                   new SelectListItem
                                   {
                                       Value = a.Id.ToString(),
                                       Text = a.Name
                                   }).ToList();
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nom = Input.Nom,
                    Prenom = Input.Prenom,
                    CodeRFID=Input.CodeRFID,
                    EmailConfirmed=true,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {   

                    //on s'assure que le role existe
                    var role = _db.Roles.Find(Input.RoleId);
                    
                    if (role != null)
                    {
                        var res = await _userManager.AddToRoleAsync(user, role.Name);
                    }

                    _logger.LogInformation("User created a new account with password.");

                    /*  var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code },
                            protocol: Request.Scheme);

                    /*   await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                           $"Please confirm your account by <a href='{HtmlEncoder.Default.Enco de(callbackUrl)}'>clicking here</a>.");
   */
                /*    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {*/
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                  /*  }*/
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            Options = _db.Roles.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

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
using GestionPresence.Data;
using GestionPresence.Models;

namespace GestionPresence.Areas.Identity.Pages.Account
{
  
    public class FirstAccountModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<FirstAccountModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private  ApplicationDbContext _db;

        public List<SelectListItem> rolesoptions;

        public FirstAccountModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<FirstAccountModel> logger,
            RoleManager<IdentityRole> roleManager,
             ApplicationDbContext db
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _db = db;

             rolesoptions=_db.Roles.Select(a =>
                                   new SelectListItem
                                   {
                                       Value = a.Id.ToString(),
                                       Text = a.Name
                                   }).ToList();
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

            

        }


        public List<SelectListItem> Options { get; set; }

         
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {

             //ajouter les role si c'est la premiere visite

            if (!await _roleManager.RoleExistsAsync(UsersRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UsersRoles.Admin));
            }
            if (!await _roleManager.RoleExistsAsync(UsersRoles.Prof))
            {
                await _roleManager.CreateAsync(new IdentityRole(UsersRoles.Prof));
            }

            if (!await _roleManager.RoleExistsAsync(UsersRoles.Etud))
            {
                await _roleManager.CreateAsync(new IdentityRole(UsersRoles.Etud));
            }

          

             if(_db.Users.FirstOrDefault()!=null){
                 return RedirectToPage("Login");
             }

        
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return Page();
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
                    CodeRFID="nocode",
                    EmailConfirmed=true,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {   

                    //on s'assure que le role existe
                    
                    
                        var res = await _userManager.AddToRoleAsync(user, "Admin");
                    

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionPresence.Data;
using GestionPresence.Models;
using Microsoft.AspNetCore.Identity;

namespace gestionpresence.Areas.Admin.Pages.Inscriptions
{
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }
    
        [TempData] 
        public int groupeid{get;set;}

          private readonly UserManager<IdentityUser> _userManager;
        public IActionResult OnGet(int? id)
        {

            if(id==null){
                return NotFound();
            }


        groupeid=(int)id;


        var etudiants=   (from x in _context.AppUSers join y in _context.UserRoles
        on x.Id equals y.UserId 
        join v in _context.Roles
        on y.RoleId equals v.Id
        where v.Name==UsersRoles.Etud
        select new {
            Id=x.Id,
            Nom= x.Nom+" "+x.Prenom
        }
        ).ToList();

        ViewData["EtudiantId"] = new SelectList(etudiants, "Id", "Nom");

            

            return Page();
        }

        [BindProperty]
        public Inscription Inscription { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Inscription.AnneeUniversitaireId=_context.AnneeUniversitaires.Where(x=>x.AnneeCourante==true)
            .FirstOrDefault().ID;
            _context.Inscriptions.Add(Inscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new {id=groupeid});
        }
    }
}

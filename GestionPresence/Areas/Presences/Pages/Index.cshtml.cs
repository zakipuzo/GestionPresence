using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GestionPresence.Areas.Presences.Pages
{
    [Authorize (Roles=UsersRoles.Admin+","+UsersRoles.Prof)]
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager=userManager;
        }

        public IList<FiliereMatiere> Filieresmatieres { get;set; }


        public async Task OnGetAsync()
        {

           

            if(User.IsInRole("Admin")){
                Filieresmatieres = await _context.FiliereMatieres
            .Include(x=>x.Matiere)
            .Include(x=>x.Filiere)
            .Include(x=>x.Filiere.Niveau)
            .Include(x=>x.Prof)
            .ToListAsync();
            }
            else{
        var profid=_userManager.GetUserId(User);
        Filieresmatieres = await _context.FiliereMatieres
            .Include(x=>x.Matiere)
            .Include(x=>x.Filiere)
            .Include(x=>x.Filiere.Niveau)
            .Where(x=>x.ProfId==profid)
            .ToListAsync();
            }

       
        }
    }
}

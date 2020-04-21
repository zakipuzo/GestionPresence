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
    public class DetailsModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(GestionPresence.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Presence> Presences { get; set; }

        public IList<Inscription> Absences { get; set; }

        //param = id seance
        public IActionResult OnGet(int? id)
        {   

            Absences=new List<Inscription>();

            if (id == null)
            {
                return NotFound();
            }
            
            var seance = _context.Seances.Where(x => x.ID == id)
            .Include(x => x.Groupe)
            .FirstOrDefault();

            Presences = _context.Presences
            .Include(x=>x.Inscription.Etudiant)
            .Where(x => x.SeanceId == id)
            .Include(w => w.Inscription).ToList();


            var Inscriptions = _context.Inscriptions
            .Include(x=>x.Etudiant)
            .Where(x => x.GroupeId == seance.GroupeId).ToList();
            
            foreach (var etudiant in Inscriptions)
            {
                bool b = false;
                foreach (var etudiantpresent in Presences)
                {
                    if (etudiant.ID == etudiantpresent.InscriptionId)
                    {
                        b = true;
                        break;
                    }

                }

                if (b == false)
                {
                    
                    Absences.Add(etudiant);
                }
            }


            return Page();
        }
    }
}

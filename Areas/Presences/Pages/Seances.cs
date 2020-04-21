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
    public class SeancesModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public SeancesModel(GestionPresence.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Seance> seances { get; set; }

        public double taux;


        public async Task<IActionResult> OnGetAsync(int? idg, int? idfm)
        {

            if (idg == null || idfm == null)
            {
                return NotFound();
            }


            //nombre de seance de la matiere idfm et groupe idg

            seances = _context.Seances.Where(x => x.GroupeId == idg && x.FiliereMatiereId == idfm)

            .Include(x => x.Salle)
            .Include(x => x.Salle.EcoleSite)

            .ToList();
            //tous les etudiants du groupe
            var etudiants = _context.Inscriptions.Where(x => x.GroupeId == idg).ToList();

         

            var absences = new List<Inscription>();

            foreach (var s in seances)
            {
                var pr = _context.Presences.Include(x => x.Inscription).Where(x => x.SeanceId == s.ID).ToList();
                

                   
                    foreach (var e in etudiants)
                    { bool b = false;

                    Inscription etudiantabsent=new Inscription();
                        
                        foreach (var p in pr)
                {
                     etudiantabsent=p.Inscription;

                        if (e.ID == p.Inscription.ID)
                        {
                            b = true;
                            break;
                        }
                    }
                   
                    if (b == false)
                    {
                        absences.Add(etudiantabsent);
                    }

                }
            }


            if(seances.Count()==0){
                taux=-1;
            }else{
                 taux=(absences.Count()/seances.Count())*100/etudiants.Count();
            }







            return Page();
        }
    }
}

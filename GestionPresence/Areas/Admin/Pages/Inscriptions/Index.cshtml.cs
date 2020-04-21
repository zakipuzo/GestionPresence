using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;
using Microsoft.AspNetCore.Authorization;

namespace gestionpresence.Areas.Admin.Pages.Inscriptions
{
     [Authorize (Roles=UsersRoles.Admin)]
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Inscription> Inscription { get;set; }

        public int groupeid;

        public string nomgroupe;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if(id==null)
            return NotFound();

          

            groupeid=(int)id;

           var nomg=(from x in _context.Groupes join y in _context.Filieres on x.FiliereId equals y.ID
            join d in _context.Niveaux on y.NiveauId equals d.ID

            where x.ID==groupeid
            select new {
            nom = d.Numero.ToString()+y.Libelle+x.Numero.ToString()
            }
            ).FirstOrDefault();

           nomgroupe= nomg.nom;

            Inscription = await _context.Inscriptions
                .Include(i => i.AnneeUniversitaire)
                .Include(i => i.Etudiant)
                .Where(i=>i.AnneeUniversitaireId==
                _context.AnneeUniversitaires.Where(x=>x.AnneeCourante==true).FirstOrDefault().ID
                && i.GroupeId==id
                ).ToListAsync();

                return Page();
        }
    }
}

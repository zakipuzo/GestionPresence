using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Groupes
{
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Groupe> Groupe { get;set; }

        public int? idfiliere;

        public string nomfiliere;

        public async Task<IActionResult> OnGetAsync(int? id)
        
        {
            if(id==null){
                return NotFound();
            }
            idfiliere=id;
            nomfiliere= _context.Filieres.Where(w=>w.ID==id).FirstOrDefault().Libelle;
            Groupe = await _context.Groupes
            .Include(x=>x.Filiere)
            .Include(x=>x.Filiere.Niveau)
            .Where(x=>x.FiliereId==id).ToListAsync();

            

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.FiliereMatieres
{
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public int? idfiliere;

        public string nomfiliere; 
        public IList<FiliereMatiere> FiliereMatiere { get;set; }

        public async Task OnGetAsync(int? id)
        {
            if(id==null){
                NotFound();
            }

            nomfiliere=_context.Filieres.Where(x=>x.ID==id).FirstOrDefault().Libelle;


        idfiliere=id;

            FiliereMatiere = await _context.FiliereMatieres
                .Where(f => f.FiliereId==id)
                .Include(f => f.Matiere)
                .Include(f => f.Prof).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Seances
{
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        
        public int? groupeid;
        public IList<Seance> Seance { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id==null){
               return  NotFound();
            }
            else{
                groupeid=id;
            }
            Seance = await _context.Seances
                .Include(s => s.FiliereMatiere.Matiere)
                .Include(s => s.Salle.EcoleSite)
                .Where(x=>x.GroupeId==groupeid)
                .ToListAsync();

                return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Niveaux
{
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Niveau> Niveau { get;set; }
        
        public int? idannee;
        public async Task OnGetAsync()
        {
            idannee= _context.AnneeUniversitaires.Where(x=>x.AnneeCourante==true).FirstOrDefault().ID;
            Niveau = await _context.Niveaux.Where(x=>x.AnneeUniversitaireId==_context.AnneeUniversitaires.Where(
                x=>x.AnneeCourante==true).FirstOrDefault().ID).ToListAsync();
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DetailsModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Niveau Niveau { get; set; }

         public List<Filiere> NiveauFilieres { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Niveau = await _context.Niveaux
                .Include(n => n.AnneeUniversitaire).FirstOrDefaultAsync(m => m.ID == id);

            if (Niveau == null)
            {
                return NotFound();
            }

             NiveauFilieres = await _context.Filieres.Where(x=>x.NiveauId==id).ToListAsync();

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Inscriptions
{
    public class DetailsModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DetailsModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Inscription Inscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inscription = await _context.Inscriptions
                .Include(i => i.AnneeUniversitaire)
                .Include(i => i.Etudiant)
                .Include(i => i.Groupe).FirstOrDefaultAsync(m => m.ID == id);

            if (Inscription == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

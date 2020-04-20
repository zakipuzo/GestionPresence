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
    public class DeleteModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DeleteModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Niveau Niveau { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Niveau = await _context.Niveaux.FindAsync(id);

            if (Niveau != null)
            {
                _context.Niveaux.Remove(Niveau);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

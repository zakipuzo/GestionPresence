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

namespace gestionpresence.Areas.Admin.Pages.Seances
{
     [Authorize (Roles=UsersRoles.Admin)]
    public class DeleteModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DeleteModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seance Seance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.Seances
                .Include(s => s.FiliereMatiere)
                .Include(s => s.Groupe)
                .Include(s => s.Salle).FirstOrDefaultAsync(m => m.ID == id);

            if (Seance == null)
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

            Seance = await _context.Seances.FindAsync(id);

            if (Seance != null)
            {
                _context.Seances.Remove(Seance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

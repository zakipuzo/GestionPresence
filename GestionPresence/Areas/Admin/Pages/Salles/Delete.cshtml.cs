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

namespace gestionpresence.Areas.Admin.Salles
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
        public Salle Salle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Salle = await _context.Salles
                .Include(s => s.EcoleSite).FirstOrDefaultAsync(m => m.ID == id);

            if (Salle == null)
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

            Salle = await _context.Salles.FindAsync(id);

            if (Salle != null)
            {
                _context.Salles.Remove(Salle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

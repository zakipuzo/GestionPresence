using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Presences
{
    public class DeleteModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DeleteModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Presence Presence { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Presence = await _context.Presences
                .Include(p => p.Inscription)
                .Include(p => p.Seance).FirstOrDefaultAsync(m => m.ID == id);

            if (Presence == null)
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

            Presence = await _context.Presences.FindAsync(id);

            if (Presence != null)
            {
                _context.Presences.Remove(Presence);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DetailsModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

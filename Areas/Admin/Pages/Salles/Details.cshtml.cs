using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Salles
{
    public class DetailsModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DetailsModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

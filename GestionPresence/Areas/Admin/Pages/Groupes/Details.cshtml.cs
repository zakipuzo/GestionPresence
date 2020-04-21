using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Groupes
{
    public class DetailsModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public DetailsModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Groupe Groupe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Groupe = await _context.Groupes
                .Include(g => g.Filiere).FirstOrDefaultAsync(m => m.ID == id);

            if (Groupe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

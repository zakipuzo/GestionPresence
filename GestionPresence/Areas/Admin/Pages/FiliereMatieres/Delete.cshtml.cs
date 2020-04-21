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

namespace gestionpresence.Areas.Admin.Pages.FiliereMatieres
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
        public FiliereMatiere FiliereMatiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FiliereMatiere = await _context.FiliereMatieres
                .Include(f => f.Filiere)
                .Include(f => f.Matiere)
                .Include(f => f.Prof).FirstOrDefaultAsync(m => m.ID == id);

            if (FiliereMatiere == null)
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

            FiliereMatiere = await _context.FiliereMatieres.FindAsync(id);

            if (FiliereMatiere != null)
            {
                _context.FiliereMatieres.Remove(FiliereMatiere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

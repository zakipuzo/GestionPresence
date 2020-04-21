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

namespace gestionpresence.Areas.Admin.Pages.Inscriptions
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inscription = await _context.Inscriptions.FindAsync(id);
var grid=Inscription.GroupeId;
            if (Inscription != null)
            {
                
                _context.Inscriptions.Remove(Inscription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index",new {id=grid});
        }
    }
}

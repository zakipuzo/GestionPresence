using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;
using Microsoft.AspNetCore.Authorization;

namespace gestionpresence.Areas.Admin.Pages.FiliereMatieres
{
     [Authorize (Roles=UsersRoles.Admin)]
    public class EditModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public EditModel(GestionPresence.Data.ApplicationDbContext context)
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
           ViewData["FiliereId"] = new SelectList(_context.Filieres, "ID", "Libelle");
           ViewData["MatiereId"] = new SelectList(_context.Matieres, "ID", "Libelle");
           ViewData["ProfId"] = new SelectList(_context.AppUSers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FiliereMatiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiliereMatiereExists(FiliereMatiere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FiliereMatiereExists(int id)
        {
            return _context.FiliereMatieres.Any(e => e.ID == id);
        }
    }
}

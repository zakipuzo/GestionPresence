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

namespace gestionpresence.Areas.Admin.Pages.Inscriptions
{
    public class EditModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public EditModel(GestionPresence.Data.ApplicationDbContext context)
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
           ViewData["AnneeUniversitaireId"] = new SelectList(_context.AnneeUniversitaires, "ID", "ID");
           ViewData["EtudiantId"] = new SelectList(_context.AppUSers, "Id", "Id");
           ViewData["GroupeId"] = new SelectList(_context.Groupes, "ID", "ID");
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

            _context.Attach(Inscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriptionExists(Inscription.ID))
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

        private bool InscriptionExists(int id)
        {
            return _context.Inscriptions.Any(e => e.ID == id);
        }
    }
}

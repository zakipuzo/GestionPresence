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

namespace gestionpresence.Areas.Admin.Pages.Seances
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
        public Seance Seance { get; set; }

        public int groupeId;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             groupeId=(int)id;

            var groupe=_context.Groupes.Where(x=>x.ID==groupeId).FirstOrDefault();

            Seance = await _context.Seances
                .Include(s => s.FiliereMatiere)
                .Include(s => s.Groupe)
                .Include(s => s.Salle).FirstOrDefaultAsync(m => m.ID == id);

            if (Seance == null)
            {
                return NotFound();
            }
            var matieres=(from x in _context.FiliereMatieres join  y in _context.Matieres
            on x.MatiereId equals y.ID
            where x.FiliereId==groupe.FiliereId
            select new{
                ID=x.ID,
                NomMat=y.Libelle
            }).ToList();

           
            
        ViewData["FiliereMatiereId"] = new SelectList(matieres, "ID", "NomMat");

           ViewData["GroupeId"] = new SelectList(_context.Groupes, "ID", "ID");
           ViewData["SalleId"] = new SelectList(_context.Salles, "ID", "CodePointeur");
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

            _context.Attach(Seance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(Seance.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index",new {id=Seance.GroupeId});
        }

        private bool SeanceExists(int id)
        {
            return _context.Seances.Any(e => e.ID == id);
        }
    }
}

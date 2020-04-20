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

namespace gestionpresence.Areas.Admin.Anneesuniversitaires
{
    public class EditModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public EditModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnneeUniversitaire AnneeUniversitaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnneeUniversitaire = await _context.AnneeUniversitaires.FirstOrDefaultAsync(m => m.ID == id);

            if (AnneeUniversitaire == null)
            {
                return NotFound();
            }
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

            _context.Attach(AnneeUniversitaire).State = EntityState.Modified;

            try
            {
                if(AnneeUniversitaire.AnneeCourante==true){

                    foreach(var annee in _context.AnneeUniversitaires){
                        if(annee.ID!=AnneeUniversitaire.ID){
                            annee.AnneeCourante=false;
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnneeUniversitaireExists(AnneeUniversitaire.ID))
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

        private bool AnneeUniversitaireExists(int id)
        {
            return _context.AnneeUniversitaires.Any(e => e.ID == id);
        }
    }
}

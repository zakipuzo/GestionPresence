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

namespace gestionpresence.Areas.Admin.Anneesuniversitaires
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnneeUniversitaire = await _context.AnneeUniversitaires.FindAsync(id);

            if (AnneeUniversitaire != null)
            {
                if(_context.AnneeUniversitaires.Count()==1){

                        return Page();

                }

                if(AnneeUniversitaire.AnneeCourante==true){
                   var nvanneecourante= _context.AnneeUniversitaires.Where(x=>x.ID!=AnneeUniversitaire.ID).FirstOrDefault();

                   nvanneecourante.AnneeCourante=true;

                _context.SaveChanges();
                }

                _context.AnneeUniversitaires.Remove(AnneeUniversitaire);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

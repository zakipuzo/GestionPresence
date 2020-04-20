using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.FiliereMatieres
{
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int? idfiliere;
        public IActionResult OnGet(int? id)
        {
           
            if(id==null){
            NotFound();
            }
            else{
                idfiliere=id;
            }

            
            idfiliere=id;

        ViewData["MatiereId"] = new SelectList(_context.Matieres, "ID", "Libelle");
        ViewData["ProfId"] = new SelectList(_context.AppUSers, "Id","Nom");
            return Page();
        }

        [BindProperty]
        public FiliereMatiere FiliereMatiere { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
        
            _context.FiliereMatieres.Add(FiliereMatiere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new {id=FiliereMatiere.FiliereId});
        }
    }
}

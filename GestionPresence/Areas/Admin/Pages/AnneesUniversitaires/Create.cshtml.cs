using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionPresence.Data;
using GestionPresence.Models;
using Microsoft.AspNetCore.Authorization;

namespace gestionpresence.Areas.Admin.Anneesuniversitaires
{
    [Authorize (Roles=UsersRoles.Admin)]
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AnneeUniversitaire AnneeUniversitaire { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
                AnneeUniversitaire.AnneeCourante=false;
            _context.AnneeUniversitaires.Add(AnneeUniversitaire);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

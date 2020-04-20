using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Presences
{
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

            [TempData]
            public int seanceid{get;set;}
        public IActionResult OnGet(int? id)
        {

            if(id==null)
            return NotFound();

        seanceid=(int)id;

        ViewData["InscriptionId"] = new SelectList(_context.Inscriptions.Where(x=>x.GroupeId==seanceid), "ID", "EtudiantId");
       
            return Page();
        }

        [BindProperty]
        public Presence Presence { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           

            _context.Presences.Add(Presence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new {id=Presence.SeanceId});
        }
    }
}

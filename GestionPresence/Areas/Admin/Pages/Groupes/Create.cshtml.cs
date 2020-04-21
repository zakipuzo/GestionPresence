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

namespace gestionpresence.Areas.Admin.Pages.Groupes
{
     [Authorize (Roles=UsersRoles.Admin)]
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            
            if(id==null){
            NotFound();
            }
            else{
             idfiliere=id;
            }

            return Page();
        }

         [BindProperty]
        public int? idfiliere{ get; set; }

        [BindProperty]
        public string erreurmessage{ get; set; }

        [BindProperty]
        public Groupe Groupe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            idfiliere=Groupe.FiliereId;

        try{
            _context.Groupes.Add(Groupe);
            await _context.SaveChangesAsync();

              return RedirectToPage("./Index",new {id=Groupe.FiliereId});   
            }catch{
                
               erreurmessage="Ce groupe existe déja";
                return Page();
            }

           
        }
    }
}

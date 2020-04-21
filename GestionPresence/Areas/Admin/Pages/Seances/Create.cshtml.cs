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

namespace gestionpresence.Areas.Admin.Pages.Seances
{
     [Authorize (Roles=UsersRoles.Admin)]
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

            [TempData]
        public int groupeId{get;set;}

        public IActionResult OnGet(int? id)
        {

            if(id==null){
                return NotFound();
            }
            
            groupeId=(int)id;

            var groupe=_context.Groupes.Where(x=>x.ID==groupeId).FirstOrDefault();
               
            var matieres=(from x in _context.FiliereMatieres join  y in _context.Matieres
            on x.MatiereId equals y.ID
            where x.FiliereId==groupe.FiliereId
            select new{
                ID=x.ID,
                NomMat=y.Libelle
            }).ToList();

           
            
        ViewData["FiliereMatiereId"] = new SelectList(matieres, "ID", "NomMat");

        var salles= (from x in _context.Salles join y in  _context.EcoleSites 
        on x.EcoleSiteId equals y.ID 
        select new {
            ID=x.ID,
            Libelle = x.Libelle+" - "+y.Libelle
        }).ToList();
       
        ViewData["SalleId"] = new SelectList(salles, "ID", "Libelle");
            return Page();
        }

        [BindProperty]
        public Seance Seance { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                    var groupe=_context.Groupes.Where(x=>x.ID==groupeId).FirstOrDefault();
               
            var matieres=(from x in _context.FiliereMatieres join  y in _context.Matieres
            on x.MatiereId equals y.ID
            where x.FiliereId==groupe.FiliereId
            select new{
                ID=x.ID,
                NomMat=y.Libelle
            }).ToList();

           
            
        ViewData["FiliereMatiereId"] = new SelectList(matieres, "ID", "NomMat");

        var salles= (from x in _context.Salles join y in  _context.EcoleSites 
        on x.EcoleSiteId equals y.ID 
        select new {
            ID=x.ID,
            Libelle = x.Libelle+" - "+y.Libelle
        }).ToList();
       
        ViewData["SalleId"] = new SelectList(salles, "ID", "Libelle");
        
                return Page();
            }

            _context.Seances.Add(Seance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new {id=Seance.GroupeId});
        }
    }
}

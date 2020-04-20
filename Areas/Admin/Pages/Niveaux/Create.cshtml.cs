using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionPresence.Data;
using GestionPresence.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionpresence.Areas.Admin.Niveaux
{
    public class CreateModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public CreateModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
         public int AnneUId{get;set;}

         [BindProperty]
        public Niveau Niveau { get; set; }
        public IActionResult OnGet(int? id)
        {

            if(id==null){
        return NotFound();
            }

            AnneUId=(int)id;
       
       
            return Page();
        }

       
        
        
       
        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AnneUId=_context.AnneeUniversitaires.Where(x=>x.AnneeCourante==true).FirstOrDefault().ID;
               
                return Page();
            }

          

          
            try{
                 var result= await _context.Niveaux.AddAsync(Niveau);  
                 await _context.SaveChangesAsync();
                   AnneUId=_context.AnneeUniversitaires.Where(x=>x.AnneeCourante==true).FirstOrDefault().ID;
                   return RedirectToPage("./Index");
            }
            catch( DbUpdateException e){

                  AnneUId=_context.AnneeUniversitaires.Where(x=>x.AnneeCourante==true).FirstOrDefault().ID;

                ErrorMessage="Niveau déjà existant";
                
                return Page();
            }
        
              
            

           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Filieres
{
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Filiere> Filiere { get;set; }

        
        public int? idniveau;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

               if (id == null)
            {
                return NotFound();
            }

            idniveau=id;

            Filiere = await _context.Filieres.Where(x=>x.NiveauId==id).ToListAsync();

            return Page();
            
        }
    }
}

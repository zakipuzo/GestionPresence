using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionPresence.Data;
using GestionPresence.Models;

namespace gestionpresence.Areas.Admin.Pages.Presences
{
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [TempData]
        public int seanceid{get;set;}

        public IList<Presence> Presence { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id )
        {
            if(id==null)
            return NotFound();


        seanceid=(int)id;

            Presence = await _context.Presences
                .Include(p => p.Inscription)
                .Where(x=>x.SeanceId==seanceid)
                .ToListAsync();

                return Page();
        }
    }
}

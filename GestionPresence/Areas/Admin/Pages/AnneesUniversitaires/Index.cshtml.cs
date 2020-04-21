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
    public class IndexModel : PageModel
    {
        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public IndexModel(GestionPresence.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AnneeUniversitaire> AnneeUniversitaire { get;set; }

        public async Task OnGetAsync()
        {
            AnneeUniversitaire = await _context.AnneeUniversitaires.ToListAsync();
        }
    }
}

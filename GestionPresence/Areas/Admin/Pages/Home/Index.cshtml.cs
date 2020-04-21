using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPresence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestionpresence.Areas.Admin.Home.Pages
{
     [Authorize (Roles=UsersRoles.Admin)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

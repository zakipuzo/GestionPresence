using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class sosoModel : PageModel
    {

        [BindProperty]
        public int resultat { get; set; }

        public void OnGet()
        {
            
        }

        class etudiant{
            public int id { get; set; }
            public string name { get; set; }
        }

        public JsonResult OnGetTestMethod(int id)
{

    return new JsonResult(new etudiant{id=id,name="bamboucha"});
}
    }
}

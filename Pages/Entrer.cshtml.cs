using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GestionPresence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using GestionPresence.Data;

namespace GestionPresence.Pages
{
    public class EntrerModel : PageModel
    {

        private readonly GestionPresence.Data.ApplicationDbContext _context;

        public EntrerModel(ApplicationDbContext context){
                _context=context;
        }

        private readonly UserManager<IdentityUser> _userManager;
        public class InputModel
        {
            [Required]
            public string coderfid { get; set; }


            [Required]
            public string codepointeur { get; set; }


        }

        public string statusmsg;

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
             

                var etudiant =   _context.AppUSers.Where(x=>x.CodeRFID==Input.coderfid).FirstOrDefault();


                if (etudiant != null)
                {
                   
                        var salle = _context.Salles.Where(x => x.CodePointeur == Input.codepointeur).FirstOrDefault();

                        if (salle != null)
                        {
                            var seances = _context.Seances.Where(x => x.SalleId == salle.ID).ToList();

                            foreach (var seance in seances)
                            {

                                var datedebut = seance.DateSeance;
                                var datefin = seance.DateSeance.AddMinutes(double.Parse(seance.durree));

                                if (DateTime.Now > datedebut && DateTime.Now < datefin)
                                {

                                    var inscription = _context.Inscriptions.Where(x => x.EtudiantId == etudiant.Id).FirstOrDefault();
                                    if (inscription != null)
                                    {

                                        var presence = new Presence { Seance = seance, Inscription = inscription };


                                        _context.Presences.Add(presence);
                                        
                                        try{
                                        _context.SaveChanges();
                                        statusmsg="Vous êtes présent!";
                                        }
                                        catch{
                                             statusmsg="Erreur!";
                                        }
                                            
                                        return Page();
                                    }

                                }
                            }

                        }


                    
                }
                

            }

 statusmsg="Erreur";
            return Page();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GestionPresence.Models
{
    public class AppUser: IdentityUser
    {
        [Required]
        [Display(Name="Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name="Prénom")]
        public string Prenom { get; set; }
        
        [Required]
        [Display(Name="Code RFID")]
        public string CodeRFID { get; set; }
        

    }
}
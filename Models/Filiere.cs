
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class Filiere
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Libelle")]
       public string Libelle { get; set; }

       [Required]
        public int NiveauId { get; set; }

        [ForeignKey("NiveauId")]
        public Niveau Niveau { get; set; }
    }
}
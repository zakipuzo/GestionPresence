using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class Inscription
    {
           [Key]
        public int ID { get; set; }

        //foreign key filiere
        [Required]
        public int GroupeId { get; set; }

        [ForeignKey("GroupeId")]
        public Groupe Groupe { get; set; }

        //foreign key AppUser
        [Required]
        public string EtudiantId { get; set; }

        [ForeignKey("EtudiantId")]
        public AppUser Etudiant { get; set; }

         
        [Required]
        public int AnneeUniversitaireId { get; set; }

        [ForeignKey("AnneeUniversitaireId")]
        public AnneeUniversitaire AnneeUniversitaire { get; set; }
        
        
    }
}
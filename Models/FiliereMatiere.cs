using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class FiliereMatiere
    {
         [Key]
        public int ID { get; set; }

         

        //foreign key filiere
        [Required]
        public int FiliereId { get; set; }

        [ForeignKey("FiliereId")]
        public Filiere Filiere { get; set; }

        //foreign key Matiere
        [Required]
        public int MatiereId { get; set; }

        [ForeignKey("MatiereId")]
        public Matiere Matiere { get; set; }

        [Required]
        public string ProfId { get; set; }

        [ForeignKey("ProfId")]
        public AppUser Prof { get; set; }

        
    }
}
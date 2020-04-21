using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPresence.Models
{
    public class Seance
    {

         [Key]
        public int ID { get; set; }

        [Required]
        public DateTime DateSeance { get; set; }
        
        [Required]
        public string durree { get; set; }

       
        
          [Required]
        public int GroupeId { get; set; }

        [ForeignKey("GroupeId")]
        public Groupe Groupe { get; set; }

        //foreign key Salle
        [Required]
        public int SalleId { get; set; }

        [ForeignKey("SalleId")]
        public Salle Salle { get; set; }

          [Required]
        public int FiliereMatiereId { get; set; }

        [ForeignKey("FiliereMatiereId")]
        public FiliereMatiere FiliereMatiere { get; set; }
    }
}
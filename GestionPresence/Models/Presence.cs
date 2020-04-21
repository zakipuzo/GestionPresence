using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class Presence
    {    
        [Key]
        public int ID { get; set; }

        [Required]
        public int InscriptionId { get; set; }

        [ForeignKey("InscriptionId")]
        public Inscription Inscription { get; set; }

         
        [Required]
        public int SeanceId { get; set; }

        [ForeignKey("SeanceId")]
        public Seance Seance { get; set; }

       
    }
}
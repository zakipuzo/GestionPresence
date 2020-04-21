using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class Groupe
    {
            [Key]
        public int ID { get; set; }
         [Required]
        public int Numero { get; set; }

        //foreign key filiere
        [Required]
        public int FiliereId { get; set; }

        [ForeignKey("FiliereId")]
        public Filiere Filiere { get; set; }
        
    }
}
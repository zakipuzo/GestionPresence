using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class Niveau
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Numero { get; set; }

        //foreign key filiere
       

           [Required]
        public int AnneeUniversitaireId { get; set; }

        [ForeignKey("AnneeUniversitaireId")]
        public AnneeUniversitaire AnneeUniversitaire { get; set; }

        
    }
}
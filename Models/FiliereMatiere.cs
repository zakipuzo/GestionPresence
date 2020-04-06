using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionpresence.Models
{
    public class FiliereMatiere
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int FiliereId { get; set; }

        [ForeignKey("FiliereId")]
        public Filiere Filiere { get; set; }

        [Required]
        public int MatiereId { get; set; }

        [ForeignKey("MatiereId")]
        public Matiere Matiere { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPresence.Models
{
    public class Matiere
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name="Libelle")]
        public string Libelle { get; set; }

    }
}
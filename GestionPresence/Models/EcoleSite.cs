using System.ComponentModel.DataAnnotations;

namespace GestionPresence.Models
{
    public class EcoleSite
    {

        [Key]
        public int ID { get; set; }

        [Required]
    
        public string Libelle { get; set; }
        
    }
}
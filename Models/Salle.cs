using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionPresence.Models;

namespace GestionPresence.Models
{
    public class Salle
    {
          [Key]
        public int ID { get; set; }
            [Required]
        [Display(Name = "Libeelle")]

       public string Libelle { get; set; }

        [Required]
        [Display(Name = "Code Pointeur")]

       public string CodePointeur { get; set; }

       


        [Required]
        [Display(Name = "EcoleSite")]
        public int EcoleSiteId { get; set; }

        [ForeignKey("EcoleSiteId")]
       public EcoleSite EcoleSite { get; set; }
        
        
    }
}
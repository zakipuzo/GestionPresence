using System.ComponentModel.DataAnnotations;

namespace GestionPresence.Models
{
    public class AnneeUniversitaire
    {
         [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Année Scolaire")]
        public int Annee { get; set; }

        public string AnneeString(){
            return Annee+"/"+(Annee+1);
        }
        
        [Required]
        public bool AnneeCourante  { get; set; }
        
    }
}
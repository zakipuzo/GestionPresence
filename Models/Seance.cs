using System.ComponentModel.DataAnnotations;

namespace gestionpresence.Models
{
    public class Seance
    {
        [Key]
        public int ID { get; set; }
        public string Heure { get; set; }
        
    }
}
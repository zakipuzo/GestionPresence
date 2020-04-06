using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionpresence.Models
{
    public class Matiere
    {
        [Key]
        public int ID { get; set; }

        
        public string Libelle { get; set; }




    }
}
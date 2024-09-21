using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models
{
    public class CandidaturaModel
    {
        [Key]
        public int idCandidatura { get; set; }

        [ForeignKey("idEgresso")]
        public int idEgresso { get; set; }

        [ForeignKey("idVaga")]
        public int idVaga { get; set; }
        public DateTime dataIncricao { get; set; } 
    }
}

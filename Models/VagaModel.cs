using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models
{
    public class VagaModel
    {
        [Key]
        public int idVaga { get; set; }

        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }
        public int tipoVaga { get; set; } 
        public string nomeVaga { get; set; } = string.Empty;
        public string descricaoVaga { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models
{
    public class PublicacaoModel
    {
        [Key]
        public int idPublicacao { get; set; }

        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }
        public string títuloPublicacao { get; set; } = string.Empty;
        public string conteudoPublicacao { get; set; } = string.Empty;
        public int avaliacaoPublicacao { get; set; }
    }
}

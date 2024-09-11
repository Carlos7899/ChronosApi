using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models.Enderecos
{
    public class CorporacaoEndereco
    {
        [Key]
        public int idCorporacaoEndereco { get; set; }

        [ForeignKey("idLogradouro")]
        public int idLogradouro { get; set; }
        public string numeroCorporacaoEndereco { get; set; } = string.Empty;
        public string complementoCorporacaoEndereco { get; set; } = string.Empty;

        [NotMapped]
        public Logradouro logradouro { get; set; }
    }
}

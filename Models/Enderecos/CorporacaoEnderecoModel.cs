using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChronosApi.Models.Enderecos
{
    public class CorporacaoEnderecoModel
    {
        [Key]
        public int idCorporacaoEndereco { get; set; }

        [ForeignKey("idLogradouro")]
        public int idLogradouro { get; set; }
        public string numeroCorporacaoEndereco { get; set; } = string.Empty;
        public string complementoCorporacaoEndereco { get; set; } = string.Empty;

        [JsonIgnore]
        public Logradouro logradouro { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models.Enderecos
{
    public class EgressoEnderecoModel
    {
        [Key]
        public int idEgressoEndereco { get; set; }

        [ForeignKey("idLogradouro")]
        public int idLogradouro { get; set; }
        public string numeroEgressoEndereco { get; set; } = string.Empty;
        public string complementoEgressoEndereco { get; set; } = string.Empty;

        [NotMapped]
        public LogradouroModel logradouro { get; set; }
    }
}

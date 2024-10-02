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

        [ForeignKey("EgressoModel")]
        public int idEgresso { get; set; }
        public string numeroEgressoEndereco { get; set; } = string.Empty;
        public string complementoEgressoEndereco { get; set; } = string.Empty;


        public EgressoModel? Egresso { get; set; }
    }
}

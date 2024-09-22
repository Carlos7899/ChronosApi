using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models.Enderecos
{
    public class VagaEndereco
    {
        [Key]
        public int idVagaEndereco { get; set; }

        [ForeignKey("idLogradouro")]
        public int idLogradouro { get; set; }
        public string numeroVagaEndereco { get; set; } = string.Empty;
        public string complementoVagaEndereco { get; set; } = string.Empty;

        [NotMapped]
        public LogradouroModel logradouro { get; set; }
    }
}

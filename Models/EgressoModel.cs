using ChronosApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChronosApi.Models
{
    public class EgressoModel
    {
        [Key]
        public int idEgresso { get; set; }
        public TipoPessoaEgresso tipoPessoaEgresso { get; set; }
        public string nomeEgresso { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string numeroEgresso { get; set; } = string.Empty;
        public string cpfEgresso { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
    }
}

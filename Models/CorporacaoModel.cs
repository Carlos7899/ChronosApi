using ChronosApi.Models.Enderecos;
using ChronosApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChronosApi.Models
{
    public class CorporacaoModel
    {
        [Key]
        public int idCorporacao { get; set; }

        public TipoCorporacao tipoCorporacao { get; set; }
        public string nomeCorporacao { get; set; } = string.Empty;
        public string emailCorporacao { get; set; } = string.Empty;
        public string numeroCorporacao { get; set; } = string.Empty;
        public string descricaoCorporacao { get; set; } = string.Empty;
        public string cnpjCorporacao { get; set; } = string.Empty;


        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime? DataAcesso { get; set; }

        [NotMapped]
        public string PasswordString { get; set; } = string.Empty;
    }
}

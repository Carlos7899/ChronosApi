using ChronosApi.Models.Curriculo;
using ChronosApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChronosApi.Models
{
    public class EgressoModel
    {
        [Key]
        public int idEgresso { get; set; }
        public TipoEgresso tipoEgresso { get; set; }
        public string nomeEgresso { get; set; } = string.Empty;

        [EmailAddress]
        public string emailEgresso { get; set; } = string.Empty;
        public string numeroEgresso { get; set; } = string.Empty;
        public string cpfEgresso { get; set; } = string.Empty;
        public byte[]? fotoPerfilEgresso { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime? DataAcesso { get; set; }

 
        [NotMapped]
        public string PasswordString { get; set; } = string.Empty;

        [NotMapped]
        public string? Token { get; set; }

        [NotMapped]
        [JsonIgnore]
        public CurriculoModel? Curriculo { get; set; }
    }
}

using ChronosApi.Models.Enums;

namespace ChronosApi.Models
{
    public class Corporacao
    {
        public int idCorporacao { get; set; }
        public int idCorporacaoEndereco { get; set; } // FK
        public TipoCorporacao tipoCorporacao { get; set; }
        public string nomeCorporacao { get; set; } = string.Empty;
        public string emailCorporacao { get; set; } = string.Empty;
        public string numeroCorporacao { get; set; } = string.Empty;
        public string descricaoCorporacao { get; set; } = string.Empty;
        public string cnpjCorporacao { get; set; } = string.Empty;
    }
}

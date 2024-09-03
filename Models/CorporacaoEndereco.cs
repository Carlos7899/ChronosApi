namespace ChronosApi.Models
{
    public class CorporacaoEndereco
    {
        public int idCorporacaoEndereco { get; set; }
        public int idLogradouro { get; set; } // FK 
        public string numeroCorporacaoEndereco { get; set; } = string.Empty;
        public string complementoCorporacaoEndereco { get; set; } = string.Empty;
    }
}

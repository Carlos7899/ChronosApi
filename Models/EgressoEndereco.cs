namespace ChronosApi.Models
{
    public class EgressoEndereco
    {
        public int idEgressoEndereco { get; set; }
        public int idLogradouro { get; set; } // FK
        public string numeroEgressoEndereco { get; set; } = string.Empty;
        public string complementoEgressoEndereco { get; set; } = string.Empty;
    }
}

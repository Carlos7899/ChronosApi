namespace ChronosApi.Models
{
    public class VagaEndereco
    {
        public int idVagaEndereco { get; set; }
        public int idLogradouro { get; set; } // FK
        public string numeroVagaEndereco { get; set; } = string.Empty;
        public string complementoVagaEndereco { get; set; } = string.Empty;
    }
}

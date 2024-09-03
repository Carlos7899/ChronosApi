namespace ChronosApi.Models
{
    public class Logradouro
    {
        public int idLogradouro { get; set; }
        public string cepLogradouro { get; set; } = string.Empty;
        public int tipoLogradouro { get; set; } //ENUM????????????????????????
        public string bairroLogradouro { get; set; } = string.Empty;
        public string cidadeLogradouro { get; set; } = string.Empty;
        public string ufLogradouro { get; set; } = string.Empty;


    }
}

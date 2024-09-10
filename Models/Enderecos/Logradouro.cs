using System.ComponentModel.DataAnnotations;

namespace ChronosApi.Models.Enderecos
{
    public class Logradouro
    {
        [Key]
        public int idLogradouro { get; set; }
        public string cepLogradouro { get; set; } = string.Empty;
        public int tipoLogradouro { get; set; }
        public string bairroLogradouro { get; set; } = string.Empty;
        public string cidadeLogradouro { get; set; } = string.Empty;
        public string ufLogradouro { get; set; } = string.Empty;


    }
}

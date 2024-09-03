using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ChronosApi.Models
{
    public class Vaga
    {
        public int idVaga { get; set; }
        public int idVagaEndereco { get; set; } // FK
        public int idCorporacao { get; set; } //FK
        public int tipoVaga { get; set; } // ENUM??????????????????????????????????????
        public string nomeVaga { get; set; } = string.Empty;
        public string descricaoVaga { get; set; } = string.Empty;
    }
}

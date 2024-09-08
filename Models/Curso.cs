using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models
{
    public class Curso
    {
        [Key]
        public int idCurso { get; set; }

        [ForeignKey("idCorporacaoEndereco")]
        public int idCorporacaoEndereco { get; set; }

        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }
        public string descricaoCurso { get; set; } = string.Empty;

    }
}

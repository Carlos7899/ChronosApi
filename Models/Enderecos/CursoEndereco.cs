using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models.Enderecos
{
    public class CursoEndereco
    {
        [Key]
        public int idCursoEndereco { get; set; }

        [ForeignKey("idLogradouro")]
        public int idLogradouro { get; set; }
        public string numeroCursoEndereco { get; set; } = string.Empty;
        public string complementoCursoEndereco { get; set; } = string.Empty;

        [NotMapped]
        public Logradouro logradouro { get; set; }
    }
}

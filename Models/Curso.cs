namespace ChronosApi.Models
{
    public class Curso
    {
        public int idCurso { get; set; }
        public int idCorporacaoEndereco { get; set; } //FK
        public int idCorporacao { get; set; } //FK
        public string descricaoCurso { get; set; } = string.Empty;

    }
}

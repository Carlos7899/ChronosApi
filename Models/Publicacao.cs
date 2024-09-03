namespace ChronosApi.Models
{
    public class Publicacao
    {

        public int idPublicacao { get; set; }
        public int idCorporacao { get; set; } //FK
        public string títuloPublicacao { get; set; } = string.Empty;
        public string conteudoPublicacao { get; set; } = string.Empty;
        public int avaliacaoPublicacao { get; set; }
    }
}

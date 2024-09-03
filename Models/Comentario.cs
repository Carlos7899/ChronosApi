namespace ChronosApi.Models
{
    public class Comentario
    {
        public int idComentario { get; set; }
        public int idPublicacao { get; set; } //FK
        public int idEgresso { get; set; } //FK
        public string comentarioPublicacao { get; set; } = string.Empty;
    }
}

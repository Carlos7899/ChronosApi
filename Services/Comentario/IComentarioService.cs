using ChronosApi.Models;

namespace ChronosApi.Services.Comentario
{
    public interface IComentarioService
    {
        Task AdicionarComentarioAsync(ComentarioModel comentario);
        Task AtualizarComentarioAsync(int idComentario, ComentarioModel comentarioAtualizado);
        Task<List<ComentarioModel>> ObterComentariosPorPublicacaoAsync(int idPublicacao);
        Task<ComentarioModel?> ObterComentarioPorIdAsync(int idComentario);
        Task<string> ValidarPublicacaoOuEgresso(int idPublicacao, int idEgresso);
    }
}

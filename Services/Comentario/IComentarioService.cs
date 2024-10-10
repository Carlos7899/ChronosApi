using ChronosApi.Models;

namespace ChronosApi.Services.Comentario
{
    public interface IComentarioService
    {
        Task AdicionarComentarioAsync(ComentarioModel comentario);
        Task AtualizarComentarioAsync(int idComentario, ComentarioModel comentarioAtualizado);
        Task<List<ComentarioModel>> ObterComentariosPorPublicacaoAsync(int idPublicacao);
<<<<<<< HEAD
        Task<ComentarioModel?> ObterComentarioPorIdAsync(int idComentario);
=======
        Task<ComentarioModel> ObterComentarioPorIdAsync(int idComentario);
>>>>>>> 52e31b7976fd34f52c6b615786316abe3a06748b
        Task<string> ValidarPublicacaoOuEgresso(int idPublicacao, int idEgresso);
    }
}

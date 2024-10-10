using ChronosApi.Models;

namespace ChronosApi.Repository.Comentario
{
    public interface IComentarioRepository
    {
        Task<List<ComentarioModel>> GetAllAsync();
<<<<<<< HEAD
        Task<ComentarioModel?> GetByIdAsync(int idComentario);
=======
        Task<ComentarioModel> GetByIdAsync(int idComentario);
>>>>>>> 52e31b7976fd34f52c6b615786316abe3a06748b
        Task AddAsync(ComentarioModel comentario);
        Task UpdateAsync(ComentarioModel comentario);
        Task DeleteAsync(int idComentario);
        Task<List<ComentarioModel>> GetByPublicacaoIdAsync(int idPublicacao);
    }
}

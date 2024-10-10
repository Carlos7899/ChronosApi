using ChronosApi.Models;

namespace ChronosApi.Repository.Comentario
{
    public interface IComentarioRepository
    {
        Task<List<ComentarioModel>> GetAllAsync();
        Task<ComentarioModel> GetByIdAsync(int idComentario);
        Task AddAsync(ComentarioModel comentario);
        Task UpdateAsync(ComentarioModel comentario);
        Task DeleteAsync(int idComentario);
        Task<List<ComentarioModel>> GetByPublicacaoIdAsync(int idPublicacao);
    }
}

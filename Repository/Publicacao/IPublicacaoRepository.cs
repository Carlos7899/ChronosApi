using ChronosApi.Models;

namespace ChronosApi.Repository.Publicacao
{
    public interface IPublicacaoRepository
    {
        Task<List<PublicacaoModel>> GetAllAsync();
        Task<PublicacaoModel?> GetIdAsync(int id);
        Task<PublicacaoModel> PostAsync(PublicacaoModel publicacao);
        Task<PublicacaoModel?> PutAsync(int id, PublicacaoModel updatedPublicacao);
        Task<PublicacaoModel?> DeleteAsync(int id);
        Task<bool> AtualizarNumeroViews(int id);
        Task<List<PublicacaoModel>> GetByCorporacaoAsync(int idCorporacao);
    }
}

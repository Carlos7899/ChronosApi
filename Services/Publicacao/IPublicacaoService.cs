using ChronosApi.Models;

namespace ChronosApi.Services.Publicacao
{
    public interface IPublicacaoService
    {
        Task<PublicacaoModel> GetAsync(int id);
        Task<bool> CorporacaoExists(int id);
    }
}

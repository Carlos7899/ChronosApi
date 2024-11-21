using ChronosApi.Models;

namespace ChronosApi.Services.Candidatura
{
    public interface ICandidaturaService
    {
        Task<CandidaturaModel> GetAsync(int id);
        Task<List<CandidaturaModel>> GetAllAsync();
        Task<CandidaturaModel> CreateAsync(CandidaturaModel candidatura);
        Task UpdateAsync(int id, CandidaturaModel updatedCandidatura);
        Task DeleteAsync(int id);
        Task<bool> CandidaturaExistsAsync(int id);
        Task<List<CandidaturaModel>> GetByEgressoAsync(int idEgresso);
        Task<List<CandidaturaModel>> GetByVagaAsync(int idVaga);
        Task<List<CandidaturaModel>> GetRecentCandidaturasByVagaAsync(int idVaga);
        Task<int> CountCandidaturasByEgressoAsync(int idEgresso);
        Task<int> CountCandidaturasByVagaAsync(int idVaga);
        Task<List<CandidaturaModel>> GetByCorporacaoAsync(int idCorporacao);
    }
}

using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Services.Candidatura
{
    public interface ICandidaturaService
    {
        #region GET
        Task<CandidaturaModel> GetAsync(int id); // Obtém uma candidatura pelo ID.
        Task<List<CandidaturaModel>> GetAllAsync(); // Obtém todas as candidaturas.
        Task<List<CandidaturaModel>> GetByEgressoAsync(int idEgresso); // Obtém candidaturas de um egresso.
        Task<List<CandidaturaModel>> GetByCorporacaoAsync(int idCorporacao); // Obtém candidaturas de uma corporação.
        #endregion

        #region POST
        Task<CandidaturaModel> CreateAsync(CandidaturaModel candidatura); // Cria uma nova candidatura.
        #endregion

        #region PUT
        Task UpdateAsync(int id, CandidaturaModel updatedCandidatura);
        #endregion

        #region DELETE
        Task DeleteAsync(int id); // Remove uma candidatura.
        #endregion
    }
}
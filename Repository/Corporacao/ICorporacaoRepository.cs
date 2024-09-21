using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Corporacao
{
    public interface ICorporacaoRepository
    {
        public Task<List<CorporacaoModel>> GetAllAsync();
        public Task<ActionResult<CorporacaoModel>> GetIdAsync(int id);
        public Task<ActionResult<CorporacaoModel>> PutAsync(int id, CorporacaoModel updatedCorporacao);
        public Task<ActionResult<CorporacaoModel>> PostAsync(CorporacaoModel corporacao);
        public Task<ActionResult<CorporacaoModel>> DeleteAsync(int id);
    }
}

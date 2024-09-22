using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Corporacao
{
    public interface ICorporacaoRepository
    {
        public Task<List<CorporacaoModel>> GetAllCorporacaoAsync();
        public Task<ActionResult<CorporacaoModel>> GetIdCorporacaoAsync(int id);
        public Task<ActionResult<CorporacaoModel>> PutCorporacaoAsync(int id, CorporacaoModel updatedCorporacao);
        public Task<ActionResult<CorporacaoModel>> PostCorporacaoAsync(CorporacaoModel corporacao);
        public Task<ActionResult<CorporacaoModel>> DeleteCorporacaoAsync(int id);
    }
}

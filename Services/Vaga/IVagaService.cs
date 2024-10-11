using ChronosApi.Models;

namespace ChronosApi.Services.Vaga
{
    public interface IVagaService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
        public Task<bool> VagaExisteAsync(int id);
        public Task<List<VagaModel>> GetVagasPorCorporacaoAsync(int idCorporacao);
        public Task<List<VagaModel>> GetVagasPorDataCriacaoAsync(DateTime dataCriacao);
    }
}

using ChronosApi.Models;

namespace ChronosApi.Repository.Vaga
{
    public interface IVagaRepository
    {
        Task<List<VagaModel>> GetAllAsync();
        Task<VagaModel?> GetIdAsync(int id);
        Task<VagaModel> PostAsync(VagaModel vaga);
        Task<VagaModel?> PutAsync(int id, VagaModel updatedVaga);
        Task<VagaModel?> DeleteAsync(int id);
    }
}

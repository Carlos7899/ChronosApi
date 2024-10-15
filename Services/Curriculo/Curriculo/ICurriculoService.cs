using ChronosApi.Models.Curriculo;

namespace ChronosApi.Services.Curriculo.Curriculo
{
    public interface ICurriculoService
    {
        Task<CurriculoModel> GetAsync(int id);
        Task PutAsync(int id, CurriculoModel curriculoAtualizado);
        Task DeleteAsync(int id);
        Task<bool> CurriculoExisteAsync(int id);
        Task CreateAsync(CurriculoModel novoCurriculo);
        Task<IEnumerable<CurriculoModel>> GetAllAsync();
        Task<IEnumerable<CurriculoModel>> GetCurriculosByEgressoAsync(int idEgresso);
    }
}

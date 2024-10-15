using ChronosApi.Models.Curriculo;

namespace ChronosApi.Services.Curriculo.formacao
{
    public interface IFormacaoService
    {
        Task<FormacaoModel> GetAsync(int id);
        Task<IEnumerable<FormacaoModel>> GetAllAsync();
        Task<IEnumerable<FormacaoModel>> GetFormacoesByCurriculoAsync(int idCurriculo);
        Task CreateAsync(FormacaoModel novaFormacao);
        Task PutAsync(int id, FormacaoModel formacaoAtualizada);
        Task DeleteAsync(int id);
        Task<bool> FormacaoExisteAsync(int id);
    }
}

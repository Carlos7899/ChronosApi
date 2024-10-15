using ChronosApi.Models.Curriculo;

namespace ChronosApi.Services.Curriculo.Experiencia
{
    public interface IExperienciaService
    {
        Task<ExperienciaModel> GetAsync(int id);
        Task PutAsync(int id, ExperienciaModel experienciaAtualizada);
        Task DeleteAsync(int id);
        Task<bool> ExperienciaExisteAsync(int id);
        Task CreateAsync(ExperienciaModel novaExperiencia);
        Task<IEnumerable<ExperienciaModel>> GetAllAsync();
        Task<IEnumerable<ExperienciaModel>> GetExperienciasByCurriculoAsync(int idCurriculo);
    }
}

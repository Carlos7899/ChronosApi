using ChronosApi.Models;

namespace ChronosApi.Services.Curso
{
    public interface ICursoService
    {

        Task CreateAsync(CursoModel novoCurso);
        Task<CursoModel> GetAsync(int id);
        Task PutAsync(int id, CursoModel cursoAtualizado);
        Task DeleteAsync(int id);
        Task<bool> CursoExisteAsync(int id);
        Task<IEnumerable<CursoModel>> GetAllAsync();
        Task<IEnumerable<CursoModel>> GetCursosByCorporacaoAsync(int idCorporacao);
        Task<IEnumerable<CursoModel>> GetCursosByNomeAsync(string nomeCurso);       
        Task<int> ContarCursosPorCorporacaoAsync(int idCorporacao);
    }
}

using ChronosApi.Models.Enderecos;

namespace ChronosApi.Services.Enderecos.CursoEndereco
{
    public interface ICursoEnderecoService
    {
        Task<IEnumerable<CursoEnderecoModel>> GetAllCursosEnderecosAsync();
        Task<CursoEnderecoModel> GetCursoEnderecoAsync(int id);
        Task<CursoEnderecoModel> CreateCursoEnderecoAsync(CursoEnderecoModel endereco);
        Task<CursoEnderecoModel> UpdateCursoEnderecoAsync(int id, CursoEnderecoModel updatedEndereco);
        Task DeleteCursoEnderecoAsync(int id);
    }
}

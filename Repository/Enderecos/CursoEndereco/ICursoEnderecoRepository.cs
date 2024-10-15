using ChronosApi.Models.Enderecos;

namespace ChronosApi.Repository.Enderecos.CursoEndereco
{
    public interface ICursoEnderecoRepository
    {
        Task<CursoEnderecoModel?> GetCursoEnderecoByIdAsync(int id);
        Task<bool> CursoExistsAsync(int idCurso);
        Task<bool> LogradouroExistsAsync(int idLogradouro);
        Task<CursoEnderecoModel> AddCursoEnderecoAsync(CursoEnderecoModel endereco);
        Task<CursoEnderecoModel> UpdateCursoEnderecoAsync(CursoEnderecoModel endereco);
        Task DeleteCursoEnderecoAsync(CursoEnderecoModel endereco);
    }
}

using ChronosApi.Models.Enderecos;
using System.Threading.Tasks;

namespace ChronosApi.Services.CorporacaoEndereco
{
    public interface ICorporacaoEnderecoService
    {
        Task<IEnumerable<CorporacaoEnderecoModel>> GetAllCorporacoesEnderecosAsync();
        Task<CorporacaoEnderecoModel> GetCorporacaoEnderecoAsync(int id);
        Task<CorporacaoEnderecoModel> CreateCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco);
        Task<CorporacaoEnderecoModel> UpdateCorporacaoEnderecoAsync(int id, CorporacaoEnderecoModel updatedEndereco);
        Task DeleteCorporacaoEnderecoAsync(int id);
    }
}

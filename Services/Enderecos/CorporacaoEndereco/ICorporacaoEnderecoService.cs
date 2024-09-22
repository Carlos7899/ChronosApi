using System.Threading.Tasks;

namespace ChronosApi.Services.CorporacaoEndereco
{
    public interface ICorporacaoEnderecoService
    {
        Task GetCorporacaoEnderecoAsync(int id);
        Task PutCorporacaoEnderecoAsync(int id);
        Task DeleteCorporacaoEnderecoAsync(int id);
    }
}

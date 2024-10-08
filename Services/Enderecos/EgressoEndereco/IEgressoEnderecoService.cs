
using ChronosApi.Models.Enderecos;
using System.Threading.Tasks;

namespace ChronosApi.Services.EgressoEndereco
{
    public interface IEgressoEnderecoService
    {
        Task<EgressoEnderecoModel> GetAsync(int id);
        Task<List<EgressoEnderecoModel>> GetAllAsync();
        Task<EgressoEnderecoModel> CreateAsync(EgressoEnderecoModel endereco);
        Task<EgressoEnderecoModel> UpdateAsync(int id, EgressoEnderecoModel updatedEndereco);
        Task DeleteAsync(int id);

    }
}


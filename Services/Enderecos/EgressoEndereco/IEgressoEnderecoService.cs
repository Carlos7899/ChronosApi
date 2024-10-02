
using ChronosApi.Models.Enderecos;
using System.Threading.Tasks;

namespace ChronosApi.Services.EgressoEndereco
{
    public interface IEgressoEnderecoService
    {
        Task<List<EgressoEnderecoModel>> GetAllEgressoEnderecosAsync();
        Task<EgressoEnderecoModel> GetEgressoEnderecoByIdAsync(int id);
        Task<EgressoEnderecoModel> CreateEgressoEnderecoAsync(EgressoEnderecoModel egressoEndereco);
        Task<EgressoEnderecoModel> PutEgressoEnderecoAsync(int id, EgressoEnderecoModel updatedEgressoEndereco);
        Task DeleteEgressoEnderecoAsync(int id);
        
    }
}


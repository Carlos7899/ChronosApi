using ChronosApi.Models.Enderecos;

namespace ChronosApi.Repository.Enderecos.EgressoEndereco
{
    public interface IEgressoEnderecoRepository
    {
        Task<EgressoEnderecoModel?> GetEgressoEnderecoByIdAsync(int id);
        Task<bool> EgressoExistsAsync(int idEgresso);
        Task<bool> LogradouroExistsAsync(int idLogradouro);
        Task<EgressoEnderecoModel> AddEgressoEnderecoAsync(EgressoEnderecoModel endereco);
        Task<EgressoEnderecoModel> UpdateEgressoEnderecoAsync(EgressoEnderecoModel endereco);
        Task DeleteEgressoEnderecoAsync(EgressoEnderecoModel endereco);
    }
}

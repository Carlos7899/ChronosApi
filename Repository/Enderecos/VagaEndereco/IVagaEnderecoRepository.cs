using ChronosApi.Models.Enderecos;

namespace ChronosApi.Repository.Enderecos.VagaEndereco
{
    public interface IVagaEnderecoRepository
    {
        Task<VagaEnderecoModel?> GetVagaEnderecoByIdAsync(int id);
        Task<bool> VagaExistsAsync(int idCorporacao);
        Task<bool> LogradouroExistsAsync(int idLogradouro);
        Task<VagaEnderecoModel> AddVagaEnderecoAsync(VagaEnderecoModel endereco);
        Task<VagaEnderecoModel> UpdateVagaEnderecoAsync(VagaEnderecoModel endereco);
        Task DeleteVagaEnderecoAsync(VagaEnderecoModel endereco);
    }
}

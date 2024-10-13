using ChronosApi.Models.Enderecos;

namespace ChronosApi.Services.Enderecos.VagaEndereco
{
    public interface IVagaEnderecoService
    {
        Task<IEnumerable<VagaEnderecoModel>> GetAllVagasEnderecosAsync();
        Task<VagaEnderecoModel> GetVagaEnderecoAsync(int id);
        Task<VagaEnderecoModel> CreateVagaEnderecoAsync(VagaEnderecoModel endereco);
        Task<VagaEnderecoModel> UpdateVagaEnderecoAsync(int id, VagaEnderecoModel updatedEndereco);
        Task DeleteVagaEnderecoAsync(int id);
    }
}

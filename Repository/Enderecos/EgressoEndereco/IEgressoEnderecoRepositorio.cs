using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Enderecos.EgressoEndereco
{
    public interface IEgressoEnderecoRepositorio
    {
        Task<List<EgressoEnderecoModel>> GetAllEgressoEnderecoAsync();
        Task<ActionResult<EgressoEnderecoModel>> GetIdEgressoEnderecoAsync(int id);
        Task<ActionResult<EgressoEnderecoModel>> PostEgressoEnderecoAsync(EgressoEnderecoModel egressoEndereco);
        Task<ActionResult<EgressoEnderecoModel>> PutEgressoEnderecoAsync(int id, EgressoEnderecoModel updatedEgressoEndereco);
        Task<ActionResult<EgressoEnderecoModel>> DeleteEgressoEnderecoAsync(int id);
    }
}

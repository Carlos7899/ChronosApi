using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Enderecos.EgressoEndereco
{
    public interface IEgressoEnderecoRepositorio
    {
        Task<List<EgressoEnderecoModel>> GetAllAsync();
        Task<EgressoEnderecoModel> GetIdAsync(int id);
        Task<EgressoEnderecoModel> PostAsync(EgressoEnderecoModel endereco);
        Task<EgressoEnderecoModel> PutAsync(int id, EgressoEnderecoModel updatedEndereco);
        Task<EgressoEnderecoModel> DeleteAsync(int id);

    }
}

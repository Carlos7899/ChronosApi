﻿using ChronosApi.Models.Enderecos;

namespace ChronosApi.Services.EgressoEndereco
{
    public interface IEgressoEnderecoService
    {
        Task<IEnumerable<EgressoEnderecoModel>> GetAllEgressosEnderecosAsync();
        Task<EgressoEnderecoModel> GetEgressoEnderecoAsync(int id);
        Task<EgressoEnderecoModel> CreateEgressoEnderecoAsync(EgressoEnderecoModel endereco);
        Task<EgressoEnderecoModel> UpdateEgressoEnderecoAsync(int id, EgressoEnderecoModel updatedEndereco);
        Task DeleteEgressoEnderecoAsync(int id);
    }
}

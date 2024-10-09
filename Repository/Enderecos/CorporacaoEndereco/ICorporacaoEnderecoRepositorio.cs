using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChronosApi.Repository.CorporacaoEndereco
{
    public interface ICorporacaoEnderecoRepository
    {
        Task<CorporacaoEnderecoModel?> GetCorporacaoEnderecoByIdAsync(int id);
        Task<bool> CorporacaoExistsAsync(int idCorporacao);
        Task<bool> LogradouroExistsAsync(int idLogradouro);
        Task<CorporacaoEnderecoModel> AddCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco);
        Task<CorporacaoEnderecoModel> UpdateCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco);
        Task DeleteCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco);
    }
}

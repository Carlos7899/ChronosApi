using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChronosApi.Repository.CorporacaoEndereco
{
    public interface ICorporacaoEnderecoRepository
    {
        Task<List<CorporacaoEnderecoModel>> GetAllCorporacaoEnderecoAsync();
        Task<ActionResult<CorporacaoEnderecoModel>> GetIdCorporacaoEnderecoAsync(int id);
        Task<ActionResult<CorporacaoEnderecoModel>> PostCorporacaoEnderecoAsync(CorporacaoEnderecoModel corporacaoEndereco);
        Task<ActionResult<CorporacaoEnderecoModel>> PutCorporacaoEnderecoAsync(int id, CorporacaoEnderecoModel updatedCorporacaoEndereco);
        Task<ActionResult<CorporacaoEnderecoModel>> DeleteCorporacaoEnderecoAsync(int id);
    }
}

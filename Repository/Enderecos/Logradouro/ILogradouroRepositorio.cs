using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Enderecos.Logradouro
{
    public interface ILogradouroRepository
    {
        Task<List<LogradouroModel>> GetAllAsync();
        Task<ActionResult<LogradouroModel?>> GetIdAsync(int id);
        Task<ActionResult<LogradouroModel>> PostAsync(LogradouroModel logradouro);
        Task<ActionResult<LogradouroModel>> PutAsync(int id, LogradouroModel updatedLogradouro);
        Task<ActionResult<LogradouroModel>> DeleteAsync(int id);
    }
}

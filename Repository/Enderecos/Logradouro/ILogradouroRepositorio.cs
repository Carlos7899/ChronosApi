using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Enderecos.Logradouro
{
    public interface ILogradouroRepository
    {
        Task<List<LogradouroModel>> GetAllLogradouroAsync();
        Task<ActionResult<LogradouroModel>> GetIdLogradouroAsync(int id);
        Task<ActionResult<LogradouroModel>> PostLogradouroAsync(LogradouroModel logradouro);
        Task<ActionResult<LogradouroModel>> PutLogradouroAsync(int id, LogradouroModel updatedLogradouro);
        Task<ActionResult<LogradouroModel>> DeleteLogradouroAsync(int id);
    }
}

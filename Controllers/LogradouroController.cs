using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Enderecos.Logradouro;
using ChronosApi.Services.Logradouro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class LogradouroController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly ILogger<LogradouroController> _logger;
        private readonly ILogradouroRepository _logradouroRepository;
        private readonly ILogradouroService _logradouroService;
    

        public LogradouroController(ILogger<LogradouroController> logger, ILogradouroRepository logradouroRepository, ILogradouroService logradouroService)
        {
            _logger = logger;
            _logradouroRepository = logradouroRepository;
            _logradouroService = logradouroService;
        }

        #region GET
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LogradouroModel>>> GetAllLogradouros()
        {
            var logradouros = await _logradouroRepository.GetAllLogradouroAsync();
            return Ok(logradouros);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<LogradouroModel>> GetLogradouroById(int id)
        {
            var logradouro = await _logradouroRepository.GetIdLogradouroAsync(id);
            await _logradouroService.GetLogradouroAsync(id);

            if (logradouro == null)
            {
                return NotFound("Logradouro não encontrado.");
            }

            return Ok(logradouro);
        }
        #endregion

        #region POST
        [HttpPost("Create")]
        public async Task<ActionResult<LogradouroModel>> CreateLogradouro(LogradouroModel logradouro)
        {
            var newLogradouro = await _logradouroRepository.PostLogradouroAsync(logradouro);
            return Ok(newLogradouro);
        }
        #endregion

        #region PUT
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<LogradouroModel>> UpdateLogradouro(int id, LogradouroModel updatedLogradouro)
        {
            await _logradouroRepository.PutLogradouroAsync(id, updatedLogradouro);
            await _logradouroService.PutLogradouroAsync(id);

            return Ok("Logradouro atualizado com sucesso.");
        }
        #endregion

        #region DELETE
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteLogradouro(int id)
        {
            await _logradouroRepository.DeleteLogradouroAsync(id);
            await _logradouroService.DeleteLogradouroAsync(id);

            return Ok("Logradouro deletado com sucesso.");
        }
        #endregion
    }
}
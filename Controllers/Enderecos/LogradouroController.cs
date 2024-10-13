using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Enderecos.Logradouro;
using ChronosApi.Services.Logradouro;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Enderecos
{

    [ApiController]
    [Route("api/[Controller]")]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;
        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroController(ILogradouroService logradouroService, ILogradouroRepository logradouroRepository)
        {
            _logradouroService = logradouroService;
            _logradouroRepository = logradouroRepository;
        }


        // CRUD pronto

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LogradouroModel>>> GetAll()
        {
            try
            {
                var logradouros = await _logradouroRepository.GetAllAsync();
                return Ok(logradouros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LogradouroModel>> Get(int id)
        {
            try
            {
                var logradouro = await _logradouroRepository.GetIdAsync(id);
                if (logradouro == null)
                {
                    return NotFound("Logradouro não encontrado.");
                }
                return Ok(logradouro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LogradouroModel>> Post([FromBody] LogradouroModel logradouro)
        {
            try
            {
                var novoLogradouro = await _logradouroRepository.PostAsync(logradouro);
                return StatusCode(201, novoLogradouro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LogradouroModel>> Put(int id, [FromBody] LogradouroModel logradouro)
        {
            try
            {
                var logradouroExists = await _logradouroService.LogradouroExisteAsync(id);
                if (!logradouroExists)
                {
                    return NotFound("Logradouro não encontrado.");
                }

                var updatedLogradouro = await _logradouroRepository.PutAsync(id, logradouro);
                return Ok(updatedLogradouro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var logradouroExists = await _logradouroService.LogradouroExisteAsync(id);
                if (!logradouroExists)
                {
                    return NotFound("Logradouro não encontrado.");
                }

                await _logradouroRepository.DeleteAsync(id);
                return Ok("Logradouro deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
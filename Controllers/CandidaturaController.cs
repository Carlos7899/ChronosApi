using ChronosApi.Models;
using ChronosApi.Services.Candidatura;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidaturaController : ControllerBase
    {
        private readonly ICandidaturaService _candidaturaService;

        public CandidaturaController(ICandidaturaService candidaturaService)
        {
            _candidaturaService = candidaturaService;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CandidaturaModel>>> GetAll()
        {
            try
            {
                var candidaturas = await _candidaturaService.GetAllAsync();
                return Ok(candidaturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CandidaturaModel>> GetById(int id)
        {
            try
            {
                var candidatura = await _candidaturaService.GetAsync(id);
                return Ok(candidatura);
            }
            catch (NotFoundException)
            {
                return NotFound("Candidatura não encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByEgresso/{idEgresso}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CandidaturaModel>>> GetByEgresso(int idEgresso)
        {
            try
            {
                var candidaturas = await _candidaturaService.GetByEgressoAsync(idEgresso);
                if (candidaturas == null || !candidaturas.Any())
                    return NotFound("Nenhuma candidatura encontrada para este egresso.");

                return Ok(candidaturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByCorporacao/{idCorporacao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CandidaturaModel>>> GetByCorporacao(int idCorporacao)
        {
            try
            {
                var candidaturas = await _candidaturaService.GetByCorporacaoAsync(idCorporacao);
                if (candidaturas == null || !candidaturas.Any())
                    return NotFound("Nenhuma candidatura encontrada para esta corporação.");

                return Ok(candidaturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region POST
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CandidaturaModel>> Post([FromBody] CandidaturaModel candidatura)
        {
            try
            {
                var novaCandidatura = await _candidaturaService.CreateAsync(candidatura);
                return CreatedAtAction(nameof(GetById), new { id = novaCandidatura.idCandidatura }, novaCandidatura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region PUT
        [HttpPut("PUT/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] CandidaturaModel candidaturaAtualizada)
        {
            try
            {
                await _candidaturaService.UpdateAsync(id, candidaturaAtualizada);
                return Ok("Candidatura atualizada com sucesso.");
            }
            catch (NotFoundException)
            {
                return NotFound("Candidatura não encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _candidaturaService.DeleteAsync(id);
                return Ok("Candidatura deletada com sucesso.");
            }
            catch (NotFoundException)
            {
                return NotFound("Candidatura não encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
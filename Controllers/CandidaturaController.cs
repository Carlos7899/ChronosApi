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

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CandidaturaModel>> Get(int id)
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
            catch (Exception)
            {
                return StatusCode(500);
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
                {
                    return NotFound("Nenhuma candidatura encontrada para este egresso.");
                }
                return Ok(candidaturas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetByVaga/{idVaga}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CandidaturaModel>>> GetByVaga(int idVaga)
        {
            try
            {
                var candidaturas = await _candidaturaService.GetByVagaAsync(idVaga);
                if (candidaturas == null || !candidaturas.Any())
                {
                    return NotFound("Nenhuma candidatura encontrada para esta vaga.");
                }
                return Ok(candidaturas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetRecentByVaga/{idVaga}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CandidaturaModel>>> GetRecentByVaga(int idVaga)
        {
            try
            {
                var candidaturas = await _candidaturaService.GetRecentCandidaturasByVagaAsync(idVaga);
                if (candidaturas == null || !candidaturas.Any())
                {
                    return NotFound("Nenhuma candidatura encontrada para esta vaga.");
                }
                return Ok(candidaturas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        #endregion

        #region COUNT
        [HttpGet("CountByEgresso/{idEgresso}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> CountByEgresso(int idEgresso)
        {
            try
            {
                int count = await _candidaturaService.CountCandidaturasByEgressoAsync(idEgresso);
                return Ok(count);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("CountByVaga/{idVaga}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> CountByVaga(int idVaga)
        {
            try
            {
                int count = await _candidaturaService.CountCandidaturasByVagaAsync(idVaga);
                return Ok(count);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CandidaturaModel>> Post([FromBody] CandidaturaModel candidatura)
        {
            try
            {
                var novaCandidatura = await _candidaturaService.CreateAsync(candidatura);
                return CreatedAtAction(nameof(Get), new { id = novaCandidatura.idCandidatura }, novaCandidatura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Put(int id, [FromBody] CandidaturaModel updatedCandidatura)
        {
            try
            {
                await _candidaturaService.UpdateAsync(id, updatedCandidatura);
                return Ok("Candidatura atualizada com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Candidatura não encontrada.");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _candidaturaService.DeleteAsync(id);
                return Ok("Candidatura deletada com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Candidatura não encontrada.");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}
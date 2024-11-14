using ChronosApi.Models.Curriculo;
using ChronosApi.Services.Curriculo.Curriculo;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Curriculo
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurriculoController : ControllerBase
    {
        private readonly ICurriculoService _curriculoService;

        public CurriculoController(ICurriculoService curriculoService)
        {
            _curriculoService = curriculoService;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CurriculoModel>>> GetAll()
        {
            try
            {
                var curriculos = await _curriculoService.GetAllAsync();
                return Ok(curriculos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurriculoModel>> Get(int id)
        {
            try
            {
                var curriculo = await _curriculoService.GetAsync(id);
                return Ok(curriculo);
            }
            catch (NotFoundException)
            {
                return NotFound("Currículo não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByEgresso/{idEgresso}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurriculoModel>> GetByEgresso(int idEgresso)
        {
            try
            {
                var curriculos = await _curriculoService.GetCurriculoByEgressoAsync(idEgresso);
                return Ok(curriculos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CurriculoModel>> Post([FromBody] CurriculoModel novoCurriculo)
        {
            try
            {
                await _curriculoService.CreateAsync(novoCurriculo);
                return CreatedAtAction(nameof(Get), new { id = novoCurriculo.idCurriculo }, novoCurriculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] CurriculoModel curriculoAtualizado)
        {
            try
            {
                await _curriculoService.PutAsync(id, curriculoAtualizado);
                return Ok("Currículo atualizado com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Currículo não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                await _curriculoService.DeleteAsync(id);
                return Ok("Currículo deletado com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Currículo não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
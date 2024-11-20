using ChronosApi.Models.Curriculo;
using ChronosApi.Services.Curriculo.Experiencia;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Curriculo
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienciaController : ControllerBase
    {
        private readonly IExperienciaService _experienciaService;

        public ExperienciaController(IExperienciaService experienciaService)
        {
            _experienciaService = experienciaService;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ExperienciaModel>>> GetAll()
        {
            try
            {
                var experiencias = await _experienciaService.GetAllAsync();

                return Ok(experiencias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExperienciaModel>> Get(int id)
        {
            try
            {
                var experiencia = await _experienciaService.GetAsync(id);

                return Ok(experiencia);
            }
            catch (NotFoundException)
            {
                return NotFound("Experiência não encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByCurriculo/{idCurriculo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExperienciaModel>>> GetByCurriculo(int idCurriculo)
        {
            try
            {
                var experiencias = await _experienciaService.GetExperienciasByCurriculoAsync(idCurriculo);

                return Ok(experiencias);
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
        public async Task<ActionResult<ExperienciaModel>> Post([FromBody] ExperienciaModel novaExperiencia)
        {
            try
            {
                await _experienciaService.CreateAsync(novaExperiencia);

                return CreatedAtAction(nameof(Get), new { id = novaExperiencia.idExperiencia }, novaExperiencia);
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
        public async Task<ActionResult> Put(int id, [FromBody] ExperienciaModel experienciaAtualizada)
        {
            try
            {
                await _experienciaService.PutAsync(id, experienciaAtualizada);
                return Ok("Experiência atualizada com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Experiência não encontrada.");
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
                await _experienciaService.DeleteAsync(id);

                return Ok("Experiência deletada com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Experiência não encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}


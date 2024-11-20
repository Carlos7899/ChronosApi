using ChronosApi.Models.Curriculo;
using ChronosApi.Services.Curriculo.formacao;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Curriculo
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormacaoController : ControllerBase
    {
        private readonly IFormacaoService _formacaoService;

        public FormacaoController(IFormacaoService formacaoService)
        {
            _formacaoService = formacaoService;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FormacaoModel>>> GetAll()
        {
            try
            {
                var formacoes = await _formacaoService.GetAllAsync();

                return Ok(formacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormacaoModel>> Get(int id)
        {
            try
            {
                var formacao = await _formacaoService.GetAsync(id);

                return Ok(formacao);
            }
            catch (NotFoundException)
            {
                return NotFound("Formação não encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByCurriculo/{idCurriculo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FormacaoModel>>> GetByCurriculo(int idCurriculo)
        {
            try
            {
                var formacoes = await _formacaoService.GetFormacoesByCurriculoAsync(idCurriculo);

                return Ok(formacoes);
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
        public async Task<ActionResult<FormacaoModel>> Post([FromBody] FormacaoModel novaFormacao)
        {
            try
            {
                await _formacaoService.CreateAsync(novaFormacao);

                return CreatedAtAction(nameof(Get), new { id = novaFormacao.idFormacao }, novaFormacao);
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
        public async Task<ActionResult> Put(int id, [FromBody] FormacaoModel formacaoAtualizada)
        {
            try
            {
                await _formacaoService.PutAsync(id, formacaoAtualizada);

                return Ok("Formação atualizada com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Formação não encontrada.");
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
                await _formacaoService.DeleteAsync(id);

                return Ok("Formação deletada com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Formação não encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
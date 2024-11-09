using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Repository.Publicacao;
using ChronosApi.Services.Publicacao;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPublicacaoService _publicacaoService;
        private readonly IPublicacaoRepository _publicacaoRepository;

        public PublicacaoController(DataContext context, IPublicacaoService publicacaoService, IPublicacaoRepository publicacaoRepository)
        {
            _context = context;
            _publicacaoService = publicacaoService;
            _publicacaoRepository = publicacaoRepository;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PublicacaoModel>>> GetAll()
        {
            try
            {
                var publicacoes = await _publicacaoRepository.GetAllAsync();
                return Ok(publicacoes);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PublicacaoModel>> Get(int id)
        {
            try
            {
                var publicacao = await _publicacaoRepository.GetIdAsync(id);
                if (publicacao == null)
                {
                    return NotFound("Publicação não encontrada.");
                }
                return Ok(publicacao);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PublicacaoModel>> Post([FromBody] PublicacaoModel publicacao)
        {
            try
            {
               
                if (!await _publicacaoService.CorporacaoExists(publicacao.idCorporacao))
                {
                    return BadRequest("Corporação não encontrada.");
                }

                var novaPublicacao = await _publicacaoRepository.PostAsync(publicacao);
                return CreatedAtAction(nameof(Get), new { id = novaPublicacao.idPublicacao }, novaPublicacao);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(int id, [FromBody] PublicacaoModel publicacao)
        {
            try
            {
         
                if (!await _publicacaoService.CorporacaoExists(publicacao.idCorporacao))
                {
                    return BadRequest("Corporação não encontrada.");
                }

                var updatedPublicacao = await _publicacaoRepository.PutAsync(id, publicacao);
                if (updatedPublicacao == null)
                {
                    return NotFound("Publicação não encontrada.");
                }

                return Accepted(new { message = "Publicação atualizada com sucesso!" });
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var publicacao = await _publicacaoRepository.DeleteAsync(id);
                if (publicacao == null)
                {
                    return NotFound("Publicação não encontrada.");
                }

                return Ok("Publicação deletada com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region UPDATE VIEWS
        [HttpPut("UpdateViews/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateViews(int id)
        {
            try
            {
                var result = await _publicacaoRepository.AtualizarNumeroViews(id);
                if (!result)
                {
                    return NotFound("Publicação não encontrada.");
                }

                return NoContent(); 
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region GET BY CORPORACAO
        [HttpGet("GetByCorporacao/{idCorporacao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PublicacaoModel>>> GetByCorporacao(int idCorporacao)
        {
            try
            {
                var publicacoes = await _publicacaoRepository.GetByCorporacaoAsync(idCorporacao);

                if (publicacoes == null || !publicacoes.Any())
                {
                    return NotFound("Nenhuma publicação encontrada para esta corporação.");
                }

                return Ok(publicacoes);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

    }
}

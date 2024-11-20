using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.CorporacaoEndereco;
using ChronosApi.Services.CorporacaoEndereco;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Enderecos
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CorporacaoEnderecoController : ControllerBase
    {
        private readonly ICorporacaoEnderecoService _corporacaoEnderecoService;
        private readonly ICorporacaoEnderecoRepository _corporacaoEnderecoRepository;

        public CorporacaoEnderecoController(ICorporacaoEnderecoService corporacaoEnderecoService, ICorporacaoEnderecoRepository corporacaoEnderecoRepository)
        {
            _corporacaoEnderecoService = corporacaoEnderecoService;
            _corporacaoEnderecoRepository = corporacaoEnderecoRepository;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CorporacaoEnderecoModel>>> GetAll()
        {
            try
            {
                var enderecos = await _corporacaoEnderecoService.GetAllCorporacoesEnderecosAsync();

                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CorporacaoEnderecoModel>> GetByIdCorporacaoEndereco(int id)
        {
            try
            {
                var endereco = await _corporacaoEnderecoService.GetCorporacaoEnderecoAsync(id);

                return Ok(endereco);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region CREATE
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CorporacaoEnderecoModel>> CreateCorporacaoEndereco([FromBody] CorporacaoEnderecoModel endereco)
        {
            try
            {
                await _corporacaoEnderecoService.CreateCorporacaoEnderecoAsync(endereco);
                var novoEndereco = await _corporacaoEnderecoRepository.AddCorporacaoEnderecoAsync(endereco);

                return CreatedAtAction(nameof(GetByIdCorporacaoEndereco), new { id = novoEndereco.idCorporacaoEndereco }, novoEndereco);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CorporacaoEnderecoModel>> Put(int id, [FromBody] CorporacaoEnderecoModel updatedEndereco)
        {
            try
            {
                var existingEndereco = await _corporacaoEnderecoService.UpdateCorporacaoEnderecoAsync(id, updatedEndereco);
                await _corporacaoEnderecoRepository.UpdateCorporacaoEnderecoAsync(existingEndereco);

                return Ok(existingEndereco);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteCorporacaoEndereco(int id)
        {
            try
            {
                var existingEndereco = await _corporacaoEnderecoRepository.GetCorporacaoEnderecoByIdAsync(id);
                if (existingEndereco == null)
                {
                    return NotFound("Endereço não encontrado.");
                }

                await _corporacaoEnderecoRepository.DeleteCorporacaoEnderecoAsync(existingEndereco);

                return Ok("Endereço deletado com sucesso!");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}

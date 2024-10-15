using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.CorporacaoEndereco;
using ChronosApi.Repository.Enderecos.CursoEndereco;
using ChronosApi.Services.CorporacaoEndereco;
using ChronosApi.Services.Enderecos.CursoEndereco;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Enderecos
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CursoEnderecoController : ControllerBase
    {
        private readonly ICursoEnderecoService _cursoEnderecoService;
        private readonly ICursoEnderecoRepository _cursoEnderecoRepository;

        public CursoEnderecoController(ICursoEnderecoService cursoEnderecoService, ICursoEnderecoRepository cursoEnderecoRepository)
        {
            _cursoEnderecoService = cursoEnderecoService;
            _cursoEnderecoRepository = cursoEnderecoRepository;
        }

        #region GET

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CursoEnderecoModel>>> GetAll()
        {
            try
            {
                var enderecos = await _cursoEnderecoService.GetAllCursosEnderecosAsync();
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
        public async Task<ActionResult<CursoEnderecoModel>> GetByIdCursoEndereco(int id)
        {
            try
            {
                var endereco = await _cursoEnderecoService.GetCursoEnderecoAsync(id);
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
        public async Task<ActionResult<CursoEnderecoModel>> CreateCursoEndereco([FromBody] CursoEnderecoModel endereco)
        {
            try
            {
                await _cursoEnderecoService.CreateCursoEnderecoAsync(endereco);

                var novoEndereco = await _cursoEnderecoRepository.AddCursoEnderecoAsync(endereco);
                return CreatedAtAction(nameof(GetByIdCursoEndereco), new { id = novoEndereco.idCursoEndereco }, novoEndereco);
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
        public async Task<ActionResult<CursoEnderecoModel>> Put(int id, [FromBody] CursoEnderecoModel updatedEndereco)
        {
            try
            {
                var existingEndereco = await _cursoEnderecoService.UpdateCursoEnderecoAsync(id, updatedEndereco);

                await _cursoEnderecoRepository.UpdateCursoEnderecoAsync(existingEndereco);

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
        public async Task<ActionResult> DeleteCursoEndereco(int id)
        {
            try
            {
                var existingEndereco = await _cursoEnderecoRepository.GetCursoEnderecoByIdAsync(id);
                if (existingEndereco == null)
                {
                    return NotFound("Endereço não encontrado.");
                }

                await _cursoEnderecoRepository.DeleteCursoEnderecoAsync(existingEndereco);
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
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Enderecos.VagaEndereco;
using ChronosApi.Services.Enderecos.VagaEndereco;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Enderecos
{

    [ApiController]
    [Route("api/[Controller]")]
    public class VagaEnderecoController : ControllerBase
    {
        private readonly IVagaEnderecoService _vagaEnderecoService;
        private readonly IVagaEnderecoRepository _vagaEnderecoRepository;

        public VagaEnderecoController(IVagaEnderecoService vagaEnderecoService, IVagaEnderecoRepository vagaEnderecoRepository)
        {
            _vagaEnderecoService = vagaEnderecoService;
            _vagaEnderecoRepository = vagaEnderecoRepository;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VagaEnderecoModel>>> GetAll()
        {
            try
            {
                var enderecos = await _vagaEnderecoService.GetAllVagasEnderecosAsync();

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
        public async Task<ActionResult<VagaEnderecoModel>> GetByIdVagaEndereco(int id)
        {
            try
            {
                var endereco = await _vagaEnderecoService.GetVagaEnderecoAsync(id);

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
        public async Task<ActionResult<VagaEnderecoModel>> CreateVagaEndereco([FromBody] VagaEnderecoModel endereco)
        {
            try
            {
             
                await _vagaEnderecoService.CreateVagaEnderecoAsync(endereco);
                var novoEndereco = await _vagaEnderecoRepository.AddVagaEnderecoAsync(endereco);

                return CreatedAtAction(nameof(GetByIdVagaEndereco), new { id = novoEndereco.idVagaEndereco }, novoEndereco);
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
        public async Task<ActionResult<VagaEnderecoModel>> Put(int id, [FromBody] VagaEnderecoModel updatedEndereco)
        {
            try
            {
                var existingEndereco = await _vagaEnderecoService.UpdateVagaEnderecoAsync(id, updatedEndereco);
                await _vagaEnderecoRepository.UpdateVagaEnderecoAsync(existingEndereco);

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
        public async Task<ActionResult> DeleteVagaEndereco(int id)
        {
            try
            {
                var existingEndereco = await _vagaEnderecoRepository.GetVagaEnderecoByIdAsync(id);
                if (existingEndereco == null)
                {
                    return NotFound("Endereço não encontrado.");
                }

                await _vagaEnderecoRepository.DeleteVagaEnderecoAsync(existingEndereco);

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

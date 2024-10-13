using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Enderecos.EgressoEndereco;
using ChronosApi.Services.EgressoEndereco;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers.Enderecos
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgressoEnderecoController : ControllerBase
    {
        private readonly IEgressoEnderecoService _egressoEnderecoService;
        private readonly IEgressoEnderecoRepository _egressoEnderecoRepository;

        public EgressoEnderecoController(IEgressoEnderecoService egressoEnderecoService, IEgressoEnderecoRepository egressoEnderecoRepository)
        {
            _egressoEnderecoService = egressoEnderecoService;
            _egressoEnderecoRepository = egressoEnderecoRepository;
        }

        #region GET

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EgressoEnderecoModel>>> GetAll()
        {
            try
            {
                var enderecos = await _egressoEnderecoService.GetAllEgressosEnderecosAsync();
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
        public async Task<ActionResult<EgressoEnderecoModel>> GetByIdEgressoEndereco(int id)
        {
            try
            {
                var endereco = await _egressoEnderecoService.GetEgressoEnderecoAsync(id);
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
        public async Task<ActionResult<EgressoEnderecoModel>> CreateEgressoEndereco([FromBody] EgressoEnderecoModel endereco)
        {
            try
            {
                // Verifica se o egresso e o logradouro existem
                await _egressoEnderecoService.CreateEgressoEnderecoAsync(endereco);

                // Adiciona o novo endereço ao repositório
                var novoEndereco = await _egressoEnderecoRepository.AddEgressoEnderecoAsync(endereco);
                return CreatedAtAction(nameof(GetByIdEgressoEndereco), new { id = novoEndereco.idEgressoEndereco }, novoEndereco);
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
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EgressoEnderecoModel>> Put(int id, [FromBody] EgressoEnderecoModel updatedEndereco)
        {
            try
            {
                var existingEndereco = await _egressoEnderecoService.UpdateEgressoEnderecoAsync(id, updatedEndereco);

                await _egressoEnderecoRepository.UpdateEgressoEnderecoAsync(existingEndereco);

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
        public async Task<ActionResult> DeleteEgressoEndereco(int id)
        {
            try
            {
                var existingEndereco = await _egressoEnderecoRepository.GetEgressoEnderecoByIdAsync(id);
                if (existingEndereco == null)
                {
                    return NotFound("Endereço não encontrado.");
                }

                await _egressoEnderecoRepository.DeleteEgressoEnderecoAsync(existingEndereco);
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

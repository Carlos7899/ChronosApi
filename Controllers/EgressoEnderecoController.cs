using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Enderecos.EgressoEndereco;
using ChronosApi.Services.EgressoEndereco;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgressoEnderecoController : ControllerBase
    {
        private readonly IEgressoEnderecoService _egressoEnderecoService;

        public EgressoEnderecoController( IEgressoEnderecoService egressoEnderecoService)
        {
            _egressoEnderecoService = egressoEnderecoService;
        }

        //SITUAÇAO: revisar e alterar Services e Repository

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAllEgressoEnderecos()
        {
            var egressoEnderecos = await _egressoEnderecoService.GetAllEgressoEnderecosAsync();
            return Ok(egressoEnderecos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEgressoEnderecoById(int id)
        {
            try
            {
                var egressoEndereco = await _egressoEnderecoService.GetEgressoEnderecoByIdAsync(id);
                return Ok(egressoEndereco);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> CreateEgressoEndereco([FromBody] EgressoEnderecoModel egressoEndereco)
        {
            if (egressoEndereco == null)
            {
                return BadRequest("Dados do endereço do egresso são obrigatórios.");
            }

            try
            {
                var createdEgressoEndereco = await _egressoEnderecoService.CreateEgressoEnderecoAsync(egressoEndereco);
                return CreatedAtAction(nameof(GetEgressoEnderecoById), new { id = createdEgressoEndereco.idEgressoEndereco }, createdEgressoEndereco);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion

        #region DELETE temporario, pois nao e´ necesario apagar apenas alterar

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEgressoEndereco(int id)
        {
            try
            {
                await _egressoEnderecoService.DeleteEgressoEnderecoAsync(id);
                return NoContent(); // Retorna um status 204 No Content
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion
    }
}
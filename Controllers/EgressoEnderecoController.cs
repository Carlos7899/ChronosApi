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
        private readonly IEgressoEnderecoService _enderecoService;

        public EgressoEnderecoController( IEgressoEnderecoService egressoEnderecoService)
        {
            _enderecoService = egressoEnderecoService;
        }

        //SITUAÇAO: revisar e alterar Services e Repository

        #region GET
        [HttpGet]
        public async Task<ActionResult<List<EgressoEnderecoModel>>> GetAll()
        {
            return Ok(await _enderecoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EgressoEnderecoModel>> Get(int id)
        {
            try
            {
                var endereco = await _enderecoService.GetAsync(id);
                return Ok(endereco);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<ActionResult<EgressoEnderecoModel>> Post([FromBody] EgressoEnderecoModel endereco)
        {
            var createdEndereco = await _enderecoService.CreateAsync(endereco);
            return CreatedAtAction(nameof(Get), new { id = createdEndereco.idEgressoEndereco }, createdEndereco);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<EgressoEnderecoModel>> Put(int id, [FromBody] EgressoEnderecoModel endereco)
        {
            try
            {
                var updatedEndereco = await _enderecoService.UpdateAsync(id, endereco);
                return Ok(updatedEndereco);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _enderecoService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
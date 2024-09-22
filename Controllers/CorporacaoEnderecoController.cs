using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.CorporacaoEndereco;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CorporacaoEnderecoController : ControllerBase
    {
        private readonly ILogger<CorporacaoEnderecoController> _logger;
        private readonly DataContext _context;
        private readonly ICorporacaoEnderecoRepository _corporacaoEnderecoRepository;

        public CorporacaoEnderecoController(ILogger<CorporacaoEnderecoController> logger, ICorporacaoEnderecoRepository corporacaoEnderecoRepository, DataContext context)
        {
            _logger = logger;
            _context = context;
            _corporacaoEnderecoRepository = corporacaoEnderecoRepository;
        }

        #region GET
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CorporacaoEnderecoModel>>> GetAll()
        {
            var corporacaoEnderecos = await _corporacaoEnderecoRepository.GetAllCorporacaoEnderecoAsync();
            return Ok(corporacaoEnderecos);
        }

        [HttpGet("GetID")]
        public async Task<ActionResult<CorporacaoEnderecoModel>> GetById(int id)
        {
            var corporacaoEndereco = await _corporacaoEnderecoRepository.GetIdCorporacaoEnderecoAsync(id);
            if (corporacaoEndereco == null)
            {
                return NotFound("Endereço de corporação não encontrado.");
            }

            return Ok(corporacaoEndereco);
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        public async Task<ActionResult<CorporacaoEnderecoModel>> Post(CorporacaoEnderecoModel corporacaoEndereco)
        {
            var newCorporacaoEndereco = await _corporacaoEnderecoRepository.PostCorporacaoEnderecoAsync(corporacaoEndereco);
            return Ok(newCorporacaoEndereco);
        }
        #endregion

        #region UPDATE
        [HttpPut("PUT")]
        public async Task<ActionResult> Put(int id, CorporacaoEnderecoModel updatedCorporacaoEndereco)
        {
            var existingCorporacaoEndereco = await _corporacaoEnderecoRepository.GetIdCorporacaoEnderecoAsync(id);
            if (existingCorporacaoEndereco == null)
            {
                return NotFound("Endereço de corporação não encontrado.");
            }

            await _corporacaoEnderecoRepository.PutCorporacaoEnderecoAsync(id, updatedCorporacaoEndereco);
            return Ok("Endereço de corporação atualizado com sucesso.");
        }
        #endregion

        #region DELETE
        [HttpDelete("DELETE")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCorporacaoEndereco = await _corporacaoEnderecoRepository.GetIdCorporacaoEnderecoAsync(id);
            if (existingCorporacaoEndereco == null)
            {
                return NotFound("Endereço de corporação não encontrado.");
            }

            await _corporacaoEnderecoRepository.DeleteCorporacaoEnderecoAsync(id);
            return Ok("Endereço de corporação deletado com sucesso.");
        }
        #endregion
    }
}
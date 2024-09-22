using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Corporacao;
using ChronosApi.Services.Corporacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorporacaoController : ControllerBase
    {
        private readonly ILogger<CorporacaoController> _logger;
        private readonly DataContext _context;
        private readonly ICorporacaoRepository _corporacaoRepository;
        private readonly ICorporacaoService _corporacaoService;

        public CorporacaoController(ILogger<CorporacaoController> logger, ICorporacaoService CorporacaoService, ICorporacaoRepository CorporacaoRepository, DataContext context)
        {
            _logger = logger;
            _context = context;
            _corporacaoRepository = CorporacaoRepository;
            _corporacaoService = CorporacaoService;
        }

        #region GET
        [HttpGet("GetAll")]
        public async Task<ActionResult<CorporacaoModel>> GetAll()
        {
            var corporacoes = await _corporacaoRepository.GetAllAsync();
            return Ok(corporacoes);
        }

        [HttpGet("GetID")]
        public async Task<ActionResult<CorporacaoModel>> GetById(int id)
        {
            var corporacao = await _corporacaoRepository.GetIdAsync(id);
            await _corporacaoService.GetAsync(id);

            return Ok(corporacao);
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        public async Task<ActionResult<CorporacaoModel>> Post(CorporacaoModel corporacao)
        {
            var newCorporacao = await _corporacaoRepository.PostAsync(corporacao);
            return Ok(newCorporacao);
        }
        #endregion

        #region UPDATE
        [HttpPut("PUT")]
        public async Task<ActionResult<CorporacaoModel>> Put(int id, CorporacaoModel updatedCorporacao)
        {
            await _corporacaoRepository.PutAsync(id, updatedCorporacao);
            await _corporacaoService.PutAsync(id);

            return Ok("Corporação atualizada com sucesso.");
        }
        #endregion

        #region DELETE
        [HttpDelete("DELETE")]
        public async Task<ActionResult> Delete(int id)
        {
            await _corporacaoRepository.DeleteAsync(id);

            return Ok("Corporação deletada com sucesso.");
        }
        #endregion
    }
}
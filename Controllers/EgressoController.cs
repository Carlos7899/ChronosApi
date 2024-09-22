using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Repository.Egresso;
using ChronosApi.Services.Egresso;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EgressoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        private readonly IEgressoService _egressoService;
        private readonly IEgressoRepository _egressoRepository;

        public EgressoController(ILogger<EgressoController> logger, IEgressoService EgressoService, IEgressoRepository EgressoRepository, DataContext context)
        {
            _context = context;
            _logger = logger;
            _egressoRepository = EgressoRepository;
            _egressoService = EgressoService;
        }

        #region GET
        [HttpGet("GetAll")]
        public async Task<ActionResult<EgressoModel>> GetAll()
        {
            var egressos = await _egressoRepository.GetAllAsync();
            return Ok(egressos);
        }

        [HttpGet("GetID")]
        public async Task<ActionResult<EgressoModel>> GetById(int id)
        {
            var egresso = await _egressoRepository.GetIdAsync(id);
            await _egressoService.GetAsync(id);

            return Ok(egresso);
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        public async Task<ActionResult<EgressoModel>> Post(EgressoModel egresso)
        {
            var newEgresso = await _egressoRepository.PostAsync(egresso);
            return Ok(newEgresso);
        }
        #endregion

        #region UPDATE
        [HttpPut("PUT")]
        public async Task<ActionResult<EgressoModel>> Put(int id, EgressoModel updatedEgresso)
        {
            await _egressoRepository.PutAsync(id, updatedEgresso);
            await _egressoService.PutAsync(id);

            return Ok("Egresso atualizado com sucesso.");
        }
        #endregion

        #region DELETE
        [HttpDelete("DELETE")]
        public async Task<ActionResult> Delete(int id)
        {
            await _egressoRepository.DeleteAsync(id);

            return Ok("Egresso deletado com sucesso.");
        }
        #endregion
    }
}
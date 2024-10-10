using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Vaga;
using ChronosApi.Services.Vaga;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IVagaService _vagaService;
        private readonly IVagaRepository _vagaRepository;

        public VagaController(DataContext context, IVagaService vagaService, IVagaRepository vagaRepository)
        {
            _context = context;
            _vagaService = vagaService;
            _vagaRepository = vagaRepository;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PublicacaoModel>>> GetAll()
        {
            try
            {
                var vagas = await _vagaRepository.GetAllAsync();
                return Ok(vagas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VagaModel>> Get(int id)
        {
            try
            {
                var vaga = await _vagaRepository.GetIdAsync(id);
                if (vaga == null)
                {
                    return NotFound("Vaga não encontrada.");
                }
                return Ok(vaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<VagaModel>> Post([FromBody] VagaModel vaga)
        {
            try
            {
                var novavaga = await _vagaRepository.PostAsync(vaga);
                return StatusCode(201, novavaga);
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VagaModel>> Put(int id, [FromBody] VagaModel vaga)
        {
            try
            {
                var vagaExists = await _vagaService.VagaExisteAsync(id);
                if (!vagaExists)
                {
                    return NotFound("Vaga não encontrada.");
                }

                var updatedVaga = await _vagaRepository.PutAsync(id, vaga);
                return Ok(updatedVaga);
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
                var publicacao = await _vagaRepository.DeleteAsync(id);
                if (publicacao == null)
                {
                    return NotFound("Vaga não encontrada.");
                }

                return Ok("Vaga deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
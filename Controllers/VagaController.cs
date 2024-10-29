using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Vaga;
using ChronosApi.Services.Exceptions;
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

        [HttpGet("GetBycorporacao/{idCorporacao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<VagaModel>>> GetVagasPorCorporacao(int idCorporacao)
        {
            try
            {
                var vagas = await _vagaService.GetVagasPorCorporacaoAsync(idCorporacao);
                return Ok(vagas);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar as vagas.");
            }
        }

        [HttpGet("GetPorDataCriacao/{dataCriacao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<VagaModel>>> GetVagasPorDataCriacao(DateTime dataCriacao)
        {
            var vagas = await _vagaService.GetVagasPorDataCriacaoAsync(dataCriacao);
            if (!vagas.Any())
            {
                return NotFound("Nenhuma vaga encontrada para a data especificada.");
            }
            return Ok(vagas);
        }

        #endregion
        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VagaModel>> Post([FromBody] VagaModel vaga)
        {
            // Verifica se o objeto vaga é nulo
            if (vaga == null)
            {
                return BadRequest("O objeto vaga não pode ser nulo.");
            }

            // Validação dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(vaga.nomeVaga))
            {
                return BadRequest("O campo nome da Vaga é obrigatório.");
            }

            if (vaga.idCorporacao <= 0) // Verifica se o idCorporacao é válido
            {
                return BadRequest("O campo idCorporacao é obrigatório.");
            }

            try
            {
                // Tenta criar a nova vaga
                var novavaga = await _vagaRepository.PostAsync(vaga);
                return CreatedAtAction(nameof(Post), new { id = novavaga.idVaga }, novavaga); // Retorna 201 Created com o local da nova vaga
            }
            catch (Exception ex)
            {
                // Logue o erro para depuração
                Console.WriteLine($"Erro ao criar vaga: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao tentar criar a vaga."); // Retorna mensagem mais descritiva
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
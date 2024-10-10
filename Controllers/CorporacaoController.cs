using ChronosApi.Models;
using ChronosApi.Repository.Corporacao;
using ChronosApi.Services.Corporacao;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CorporacaoController : ControllerBase
    {
  
        private readonly ICorporacaoRepository _corporacaoRepository;
        private readonly ICorporacaoService _corporacaoService;

        public CorporacaoController( ICorporacaoService CorporacaoService, ICorporacaoRepository CorporacaoRepository)
        {
            _corporacaoRepository = CorporacaoRepository;
            _corporacaoService = CorporacaoService;
        }

        //CRUD pronto

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CorporacaoModel>> GetAll()
        {
            try
            {
                var corporacoes = await _corporacaoRepository.GetAllAsync();
                return StatusCode(200, corporacoes);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CorporacaoModel>> Get(int id)
        {
            try
            {
                var egresso = await _corporacaoRepository.GetIdAsync(id);

                await _corporacaoService.GetAsync(id);

                return Ok(egresso);

            }

            catch (Exception)
            {
                return StatusCode(500);

            }
        }
        #endregion

        //Nao e´ necessario, basta registrar e depois update, possivelmente vou remover
        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CorporacaoModel>> Post([FromBody] CorporacaoModel corporacao)
        {
            try
            {
                var novoegresso = await _corporacaoRepository.PostAsync(corporacao);
                return StatusCode(201, novoegresso);

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
        public async Task<ActionResult<CorporacaoModel>> Put(int id, [FromBody] CorporacaoModel corporacao)
        {
            try
            {
                var egressoExists = await _corporacaoService.CorporacaoExisteAsync(id);
                if (!egressoExists)
                {
                    return NotFound("Egresso não encontrado.");
                }

                var updatedEgresso = await _corporacaoRepository.PutAsync(id, corporacao);

                if (updatedEgresso == null)
                {
                    return Conflict("Não foi possível atualizar o egresso.");
                }

                return Ok("Dados do Egresso atualizados com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region DELETE
        [HttpDelete("Delete/{id}")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _corporacaoService.DeleteAsync(id);
                await _corporacaoRepository.DeleteAsync(id);

                return Ok("Egresso Deletado com sucesso!");

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region REGISTRAR
        [HttpPost("Registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarUsuario(string email, string passwordString)
        {
            try
            {
                await _corporacaoService.RegistrarCorporacaoExistente(email);
                await _corporacaoRepository.RegistrarCorporacaoAsync(email, passwordString);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region AUTENTICAR
        [HttpPost("Autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AutenticarCorporacao(string email, string passwordString)
        {
            try
            {
                string token = await _corporacaoService.AutenticarCorporacaoAsync(email, passwordString);
                await _corporacaoRepository.AutenticarCorporacaoAsync(email, passwordString);

                return Ok(new { Token = token });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

        #region ALTERAR-SENHA
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaCorporacao(string email, string novaSenha)
        {
            try
            {
                await _corporacaoService.GetCorporacaoAsync(email);
                await _corporacaoRepository.AlterarSenhaCorporacaoAsync(email, novaSenha);

                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
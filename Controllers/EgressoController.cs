using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Repository.Egresso;
using ChronosApi.Services.Egresso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EgressoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEgressoService _egressoService;
        private readonly IEgressoRepository _egressoRepository;

        public EgressoController(DataContext context, IEgressoService egressoService, IEgressoRepository egressoRepository)
        {

            _context = context;
            _egressoService = egressoService;
            _egressoRepository = egressoRepository;
         
        }


        //Controller Pronta

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EgressoModel>> GetAll()
        {
            try
            {
                var egressos = await _egressoRepository.GetAllAsync();
                return StatusCode(200, egressos);

            }

            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EgressoModel>> Get(int id)
        {
            try
            {
                var egresso = await _egressoRepository.GetIdAsync(id);

                await _egressoService.GetAsync(id);

                return Ok(egresso);

            }

            catch (System.Exception)
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
        public async Task<ActionResult<EgressoModel>> Post([FromBody] EgressoModel egresso)
        {
            try
            {
                var novoegresso = await _egressoRepository.PostAsync(egresso);
                return StatusCode(201, novoegresso);

            }

            catch (System.Exception)
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
        public async Task<ActionResult<EgressoModel>> Put(int id, [FromBody] EgressoModel egresso)
        {
            try
            {
                // Valida se o Egresso existe no Service
                var egressoExists = await _egressoService.EgressoExisteAsync(id);
                if (!egressoExists)
                {
                    return NotFound("Egresso não encontrado.");
                }

                // Atualiza os dados permitidos no Repository
                var updatedEgresso = await _egressoRepository.PutAsync(id, egresso);

                if (updatedEgresso == null)
                {
                    return Conflict("Não foi possível atualizar o egresso.");
                }

                return Ok("Dados do Egresso atualizados com sucesso!");
            }
            catch (System.Exception)
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
                await _egressoService.DeleteAsync(id);
                await _egressoRepository.DeleteAsync(id);

                return Ok("Egresso Deletado com sucesso!");

            }
            catch (System.Exception)
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
                await _egressoService.RegistrarEgressoExistente(email);
                await _egressoRepository.RegistrarEgressoAsync(email, passwordString);

                return StatusCode(200);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region AUTENTICAR
        [HttpPost("Autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AutenticarEgresso(string email, string passwordString)
        {
            try
            {
                // Autenticar e gerar o token via service
                string token = await _egressoService.AutenticarEgressoAsync(email, passwordString);

                // Armazenar no banco via repository, se necessário
                await _egressoRepository.AutenticarEgressoAsync(email, passwordString);

                // Retornar o token ao cliente
                return Ok(new { Token = token });

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

        #region ALTERAR-SENHA
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaEgresso(string email, string novaSenha)
        {
            try
            {
                await _egressoService.GetEgressoAsync(email);
                await _egressoRepository.AlterarSenhaEgressoAsync(email, novaSenha);

                return Ok(200);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    


    }
}
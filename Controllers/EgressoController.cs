using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Repository.Egresso;
using ChronosApi.Services.Egresso;
using ChronosApi.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EgressoController : ControllerBase
    {
        private readonly IEgressoService _egressoService;
        private readonly IEgressoRepository _egressoRepository;
        private readonly IConfiguration _configuration;

        public EgressoController(IEgressoService egressoService, IEgressoRepository egressoRepository, IConfiguration configuration )
        {

            _configuration = configuration;
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
        public async Task<ActionResult<EgressoModel>> Put(int id, [FromBody] EgressoModel egresso)
        {
            try
            {
                var egressoExists = await _egressoService.EgressoExisteAsync(id);
                if (!egressoExists)
                {
                    return NotFound("Egresso não encontrado.");
                }

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
        public async Task<IActionResult> RegistrarUsuario([FromBody] EgressoModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.emailEgresso) || string.IsNullOrEmpty(model.PasswordString))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            try
            {
             
                if (await _egressoRepository.EgressoExisteEmailAsync(model.emailEgresso))
                {
                    return BadRequest("Egresso já registrada.");
                }

           
                await _egressoRepository.RegistrarEgressoAsync(model.emailEgresso, model.PasswordString);

                return Ok("Registro realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region AUTENTICAR
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AutenticarEgresso(EgressoModel credenciais)
        {
            if (credenciais == null || string.IsNullOrEmpty(credenciais.emailEgresso) || string.IsNullOrEmpty(credenciais.PasswordString))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            try
            {
                var egresso = await _egressoRepository.GetAllAsync();
                var egressoEncontrada = egresso.FirstOrDefault(c => c.emailEgresso.ToLower() == credenciais.emailEgresso.ToLower());

                if (egressoEncontrada == null)
                {
                    throw new Exception("Egresso não encontrada.");
                }

                // Verifica se a senha está correta
                if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, egressoEncontrada.PasswordHash, egressoEncontrada.PasswordSalt))
                {
                    throw new Exception("Senha incorreta.");
                }

                egressoEncontrada.DataAcesso = DateTime.Now;
                await _egressoRepository.PutAsync(egressoEncontrada.idEgresso, egressoEncontrada);

                // Cria o token
                string token = CriarToken(egressoEncontrada);
                egressoEncontrada.Token = token; // Se quiser incluir o token no retorno

                // Retorna o token e o ID da corporação
                return Ok(new
                {
                    Token = token,
                    IdEgresso = egressoEncontrada.idEgresso
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private string CriarToken(EgressoModel usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.idEgresso.ToString()),
                new Claim(ClaimTypes.Email, usuario.emailEgresso),
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("configuracaoToken:Chave").Value ?? ""));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
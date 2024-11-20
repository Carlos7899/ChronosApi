using ChronosApi.Models;
using ChronosApi.Repository.Corporacao;
using ChronosApi.Services.Corporacao;
using ChronosApi.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorporacaoController : ControllerBase
    {
        private readonly ICorporacaoRepository _corporacaoRepository;
        private readonly ICorporacaoService _corporacaoService;
        private readonly IConfiguration _configuration;

        public CorporacaoController( ICorporacaoService CorporacaoService, ICorporacaoRepository CorporacaoRepository, IConfiguration configuration)
        {
            _corporacaoRepository = CorporacaoRepository;
            _corporacaoService = CorporacaoService;
            _configuration = configuration;
        }

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

        #region CREATE
        // Não é necessario, basta registrar e depois update, possivelmente será removido
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
                    return NotFound("Corporção não encontrado.");
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

                return Ok("Egresso deletado com sucesso!");
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
        public async Task<IActionResult> RegistrarUsuario([FromBody] CorporacaoModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.emailCorporacao) || string.IsNullOrEmpty(model.PasswordString))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            try
            {
                if (await _corporacaoRepository.CorporacaoExisteEmailAsync(model.emailCorporacao))
                {
                    return BadRequest("Corporação já registrada.");
                }

                await _corporacaoRepository.RegistrarCorporacaoAsync(model.emailCorporacao, model.PasswordString);

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
        public async Task<IActionResult> AutenticarCorporacao(CorporacaoModel credenciais)
        {
            if (credenciais == null || string.IsNullOrEmpty(credenciais.emailCorporacao) || string.IsNullOrEmpty(credenciais.PasswordString))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            try
            {
                var corporacao = await _corporacaoRepository.GetAllAsync();
                var corporacaoEncontrada = corporacao.FirstOrDefault(c => c.emailCorporacao.ToLower() == credenciais.emailCorporacao.ToLower());

                if (corporacaoEncontrada == null)
                {
                    throw new Exception("Corporação não encontrada.");
                }

                if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, corporacaoEncontrada.PasswordHash, corporacaoEncontrada.PasswordSalt))
                {
                    throw new Exception("Senha incorreta.");
                }

                corporacaoEncontrada.DataAcesso = DateTime.Now;
                await _corporacaoRepository.PutAsync(corporacaoEncontrada.idCorporacao, corporacaoEncontrada);

                string token = CriarToken(corporacaoEncontrada);

                return Ok(new
                {
                    Token = token,
                    IdCorporacao = corporacaoEncontrada.idCorporacao 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        private string CriarToken(CorporacaoModel usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.idCorporacao.ToString()),
                new Claim(ClaimTypes.Email, usuario.emailCorporacao),
                new Claim(ClaimTypes.Name, usuario.nomeCorporacao),
                 
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
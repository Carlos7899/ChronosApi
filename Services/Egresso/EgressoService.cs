using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using ChronosApi.Services.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChronosApi.Services.Egresso
{
    public class EgressoService : IEgressoService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;     
        public EgressoService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task GetAsync(int id)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);
            if (egresso == null)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }
        }
        public async Task PutAsync(int id)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);
            if (egresso == null)
            {
                throw new ConflictException("Dados inválidos.");
            }

        }
        public async Task DeleteAsync(int id)
        {
            var existingEgresso = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);
            if (existingEgresso == null)
            { 
                throw new NotFoundException("Egresso não encontrado."); 
            }
        }
        private async Task<bool> EgressoExistente(string email)
        {

            if (await _context.TB_EGRESSO.AnyAsync(x => x.emailEgresso.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task RegistrarEgressoExistente(string email)
        {
            var utilizador = await _context.TB_EGRESSO.FirstOrDefaultAsync(u => u.emailEgresso == email);

            if (await EgressoExistente(email))
            {
                throw new Exception("Este email já possui um login.");
            }
        }

        public async Task<string> AutenticarEgressoAsync(string email, string passwordString)
        {
            EgressoModel? usuario = await _context.TB_EGRESSO.FirstOrDefaultAsync(x => x.emailEgresso.ToLower().Equals(email.ToLower()));


            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            else if (!Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt))
            {
                throw new Exception("Senha incorreta.");
            }

            return CriarToken(usuario);
        }

        private string CriarToken(EgressoModel usuario) 
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, usuario.idEgresso.ToString()),
                 new Claim(ClaimTypes.Email, usuario.emailEgresso)
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

        public async Task GetEgressoAsync(string email)
        {
            EgressoModel? usuario = await _context.TB_EGRESSO.FirstOrDefaultAsync(x => x.emailEgresso.ToLower().Equals(email.ToLower()));
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
        }

        public async Task<bool> EgressoExisteAsync(int id)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync(e => e.idEgresso == id);
            return egresso != null;
        }
    }
}

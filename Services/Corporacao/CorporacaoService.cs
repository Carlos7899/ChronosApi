using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using ChronosApi.Services.Utils;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Corporacao
{
    public class CorporacaoService : ICorporacaoService
    {
        private readonly DataContext _context;
        public CorporacaoService(DataContext context)
        {
            _context = context;

        }
        public async Task GetAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);
            if (corporacao == null)
            {
                throw new NotFoundException("Corporaçao não encontrado.");
            }
        }
        public async Task PutAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);
            if (corporacao == null)
            {
                throw new ConflictException("Dados inválidos.");
            }

        }
        public async Task DeleteAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);
            if (corporacao == null)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }
        }

        private async Task<bool> CorporacaoExistente(string email)
        {

            if (await _context.TB_CORPORACAO.AnyAsync(x => x.emailCorporacao.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task RegistrarCorporacaoExistente(string email)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync(u => u.emailCorporacao == email);

            if (await CorporacaoExistente(email))
            {
                throw new System.Exception("Este email ja possui login");
            }

        }

        public async Task AutenticarCorporacaoAsync(string email, string passwordString)
        {
            CorporacaoModel? usuario = await _context.TB_CORPORACAO.FirstOrDefaultAsync(x => x.emailCorporacao.ToLower().Equals(email.ToLower()));


            if (usuario == null)
            {
                throw new System.Exception("Usuário não encontrado.");
            }

            else if (!Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt))
            {
                throw new System.Exception("Senha incorreta.");
            }
        }

        public async Task GetCorporacaoAsync(string email)
        {
            CorporacaoModel? usuario = await _context.TB_CORPORACAO.FirstOrDefaultAsync(x => x.emailCorporacao.ToLower().Equals(email.ToLower()));
            if (usuario == null)
            {
                throw new System.Exception("Usuário não encontrado.");
            }
        }

        public async Task<bool> CorporacaoExisteAsync(int id)
        {
            var egresso = await _context.TB_CORPORACAO.FirstOrDefaultAsync(c => c.idCorporacao == id);
            return egresso != null;
        }




    }
}

    
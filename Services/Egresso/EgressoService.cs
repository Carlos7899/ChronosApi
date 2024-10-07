using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using ChronosApi.Services.Utils;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Egresso
{
    public class EgressoService : IEgressoService
    {
        private readonly DataContext _context;
        public EgressoService(DataContext context)
        {
            _context = context;
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
            var utilizador = await _context.TB_EGRESSO .FirstOrDefaultAsync(u => u.emailEgresso == email);

            if (await EgressoExistente(email))
            {
                throw new System.Exception("Este email ja possui login");
            }

        }

        public async Task AutenticarEgressoAsync(string email, string passwordString)
        {
            EgressoModel? usuario = await _context.TB_EGRESSO.FirstOrDefaultAsync(x => x.emailEgresso.ToLower().Equals(email.ToLower()));


            if (usuario == null)
            {
                throw new System.Exception("Usuário não encontrado.");
            }

            else if (!Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt))
            {
                throw new System.Exception("Senha incorreta.");
            }
        }

        public async Task GetEgressoAsync(string email)
        {
            EgressoModel? usuario = await _context.TB_EGRESSO.FirstOrDefaultAsync(x => x.emailEgresso.ToLower().Equals(email.ToLower()));
            if (usuario == null)
            {
                throw new System.Exception("Usuário não encontrado.");
            }
        }

        public async Task<bool> EgressoExisteAsync(int id)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync(e => e.idEgresso == id);
            return egresso != null;
        }



    }
}

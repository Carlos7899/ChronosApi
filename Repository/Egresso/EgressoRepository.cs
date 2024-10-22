using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Egresso
{
    public class EgressoRepository : IEgressoRepository
    {
        private readonly DataContext _context;
        public EgressoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EgressoModel>> GetAllAsync()
        {
            var egresso = await _context.TB_EGRESSO.ToListAsync();
            return egresso;
        }

        public async Task<ActionResult<EgressoModel?>> GetIdAsync(int id)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync(e => e.idEgresso == id);
            return egresso;
        }

        public async Task<ActionResult<EgressoModel>> PostAsync(EgressoModel egresso)
        {
            egresso.idEgresso = 0;
            _context.TB_EGRESSO.Add(egresso);
            await _context.SaveChangesAsync();
            return egresso;
        }

        public async Task<ActionResult<EgressoModel>> PutAsync(int id, EgressoModel updatedEgresso)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);

            if (egresso == null)
            {
                return new NotFoundResult();
            }

            egresso.nomeEgresso = updatedEgresso.nomeEgresso;
            egresso.tipoEgresso = updatedEgresso.tipoEgresso;
            egresso.numeroEgresso = updatedEgresso.numeroEgresso;
            egresso.cpfEgresso = updatedEgresso.cpfEgresso;

            _context.Entry(egresso).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return egresso;
        }
            
        public async Task<ActionResult<EgressoModel>> DeleteAsync(int id)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync(e => e.idEgresso == id);

            if (egresso == null)
            {
                return new NotFoundResult();
            }

            _context.TB_EGRESSO.Remove(egresso);
            await _context.SaveChangesAsync();

            return egresso;
        }

        public async Task RegistrarEgressoAsync(string email, string passwordString)
        {
            Criptografia.CriarPasswordHash(passwordString, out byte[] hash, out byte[] salt);

            EgressoModel egresso = new EgressoModel
            {
                emailEgresso = email,
                PasswordString = string.Empty,
                PasswordHash = hash,
                PasswordSalt = salt
            };


            await _context.TB_EGRESSO.AddAsync(egresso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AutenticarEgressoAsync(string email, string passwordString)
        {
            EgressoModel? usuario = await _context.TB_EGRESSO.FirstOrDefaultAsync(x => x.emailEgresso.ToLower().Equals(email.ToLower()));

            if (usuario != null)
            {

                bool senhaValida = Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt);

                if (senhaValida)
                {

                    usuario.DataAcesso = System.DateTime.Now;
                    _context.TB_EGRESSO.Update(usuario);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public async Task AlterarSenhaEgressoAsync(string email, string novaSenha)
        {
            EgressoModel? usuario = await _context.TB_EGRESSO.FirstOrDefaultAsync(x => x.emailEgresso == email);

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            Criptografia.CriarPasswordHash(novaSenha, out byte[] novoHash, out byte[] novoSal);

            usuario.PasswordHash = novoHash;
            usuario.PasswordSalt = novoSal;

            var attach = _context.Attach(usuario);
            attach.Property(x => x.PasswordHash).IsModified = true;
            attach.Property(x => x.PasswordSalt).IsModified = true;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> EgressoExisteEmailAsync(string email)
        {
            var corporacoes = await GetAllAsync();
            return corporacoes.Any(c => c.emailEgresso.ToLower() == email.ToLower());
        }

    }
}

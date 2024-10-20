using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Corporacao
{
    public class CorporacaoRepository : ICorporacaoRepository
    {
        private readonly DataContext _context;
        public CorporacaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CorporacaoModel>> GetAllAsync()
        {
            var corporacao = await _context.TB_CORPORACAO.ToListAsync();
            return corporacao;
        }

        public async Task<ActionResult<CorporacaoModel?>> GetIdAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync(c => c.idCorporacao == id);
            return corporacao;
        }

        public async Task<ActionResult<CorporacaoModel>> PostAsync(CorporacaoModel corporacao)
        {
            corporacao.idCorporacao = 0;
            _context.TB_CORPORACAO.Add(corporacao);
            await _context.SaveChangesAsync();
            return corporacao;
        }

        public async Task<ActionResult<CorporacaoModel>> PutAsync(int id, CorporacaoModel updatedCorporacao)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);

            if (corporacao == null)
            {
                return new NotFoundResult();
            }

            corporacao.nomeCorporacao = updatedCorporacao.nomeCorporacao;
            corporacao.tipoCorporacao = updatedCorporacao.tipoCorporacao;
            corporacao.numeroCorporacao = updatedCorporacao.numeroCorporacao;
            corporacao.cnpjCorporacao = updatedCorporacao.cnpjCorporacao;
            corporacao.descricaoCorporacao = updatedCorporacao.descricaoCorporacao;

            _context.Entry(corporacao).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return corporacao;
        }

        public async Task<ActionResult<CorporacaoModel>> DeleteAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync(c => c.idCorporacao == id);

            if (corporacao == null)
            {
                return new NotFoundResult();
            }

            _context.TB_CORPORACAO.Remove(corporacao);
            await _context.SaveChangesAsync();

            return corporacao;
        }

        public async Task RegistrarCorporacaoAsync(string email, string passwordString)
        {
            Criptografia.CriarPasswordHash(passwordString, out byte[] hash, out byte[] salt);

            CorporacaoModel corporacao = new CorporacaoModel
            {
                emailCorporacao = email,
                PasswordString = string.Empty,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            await _context.TB_CORPORACAO.AddAsync(corporacao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AutenticarCorporacaoAsync(string email, string passwordString)
        {
            CorporacaoModel? usuario = await _context.TB_CORPORACAO.FirstOrDefaultAsync(x => x.emailCorporacao.ToLower().Equals(email.ToLower()));

            if (usuario != null)
            {

                bool senhaValida = Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt);

                if (senhaValida)
                {

                    usuario.DataAcesso = System.DateTime.Now;
                    _context.TB_CORPORACAO.Update(usuario);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public async Task AlterarSenhaCorporacaoAsync(string email, string novaSenha)
        {
            CorporacaoModel? usuario = await _context.TB_CORPORACAO.FirstOrDefaultAsync(x => x.emailCorporacao == email);

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
        public async Task<bool> CorporacaoExisteEmailAsync(string email)
        {
            var corporacoes = await GetAllAsync();
            return corporacoes.Any(c => c.emailCorporacao.ToLower() == email.ToLower());
        }
    }
}

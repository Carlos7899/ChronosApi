using ChronosApi.Data;
using ChronosApi.Models;
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

        #region GET
        public async Task<List<CorporacaoModel>> GetAllCorporacaoAsync()
        {
            var corporacao = await _context.TB_CORPORACAO.ToListAsync();
            return corporacao;
        }

        public async Task<ActionResult<CorporacaoModel>> GetIdCorporacaoAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync(c => c.idCorporacao == id);
            return corporacao;
        }
        #endregion

        #region POST
        public async Task<ActionResult<CorporacaoModel>> PostCorporacaoAsync(CorporacaoModel corporacao)
        {
            corporacao.idCorporacao = 0;
            _context.TB_CORPORACAO.Add(corporacao);
            await _context.SaveChangesAsync();
            return corporacao;
        }
        #endregion

        #region PUT
        public async Task<ActionResult<CorporacaoModel>> PutCorporacaoAsync(int id, CorporacaoModel updatedCorporacao)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);

            corporacao.nomeCorporacao = updatedCorporacao.nomeCorporacao;
            corporacao.descricaoCorporacao = updatedCorporacao.descricaoCorporacao;
            corporacao.tipoCorporacao = updatedCorporacao.tipoCorporacao;
            corporacao.numeroCorporacao = updatedCorporacao.numeroCorporacao;
            corporacao.emailCorporacao = updatedCorporacao.emailCorporacao;
            corporacao.cnpjCorporacao = updatedCorporacao.cnpjCorporacao;

            _context.Entry(corporacao).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return corporacao;
        }
        #endregion

        #region DELETE        
        public async Task<ActionResult<CorporacaoModel>> DeleteCorporacaoAsync(int id)
        {

            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync(c => c.idCorporacao == id);
            _context.TB_CORPORACAO.Remove(corporacao);
            await _context.SaveChangesAsync();

            return corporacao;
        }
        #endregion
    }
}

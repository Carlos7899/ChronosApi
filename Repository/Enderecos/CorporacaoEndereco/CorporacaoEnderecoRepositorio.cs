using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.CorporacaoEndereco
{
    public class CorporacaoEnderecoRepository : ICorporacaoEnderecoRepository
    {
        private readonly DataContext _context;
        public CorporacaoEnderecoRepository(DataContext context)
        {
            _context = context;
        }

        #region GET
        public async Task<List<CorporacaoEnderecoModel>> GetAllCorporacaoEnderecoAsync()
        {
            var corporacaoEnderecos = await _context.TB_CORPORACAO_ENDERECO.ToListAsync();
            return corporacaoEnderecos;
        }

        public async Task<ActionResult<CorporacaoEnderecoModel>> GetIdCorporacaoEnderecoAsync(int id)
        {
            var corporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO.FirstOrDefaultAsync(ce => ce.idCorporacaoEndereco == id);
            return corporacaoEndereco;
        }
        #endregion

        #region POST
        public async Task<ActionResult<CorporacaoEnderecoModel>> PostCorporacaoEnderecoAsync(CorporacaoEnderecoModel corporacaoEndereco)
        {
          _context.TB_CORPORACAO_ENDERECO.Add(corporacaoEndereco);
          await _context.SaveChangesAsync();
          return corporacaoEndereco;
        }

        #endregion

        #region PUT
        public async Task<ActionResult<CorporacaoEnderecoModel>> PutCorporacaoEnderecoAsync(int id, CorporacaoEnderecoModel updatedCorporacaoEndereco)
        {
            var corporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO.FirstOrDefaultAsync(ce => ce.idCorporacaoEndereco == id);

            if (corporacaoEndereco == null)
            {
                return null;
            }

            corporacaoEndereco.numeroCorporacaoEndereco = updatedCorporacaoEndereco.numeroCorporacaoEndereco;
            corporacaoEndereco.complementoCorporacaoEndereco = updatedCorporacaoEndereco.complementoCorporacaoEndereco;

            _context.Entry(corporacaoEndereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return corporacaoEndereco;
        }
        #endregion

        #region DELETE        
        public async Task<ActionResult<CorporacaoEnderecoModel>> DeleteCorporacaoEnderecoAsync(int id)
        {
            var corporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO.FirstOrDefaultAsync(ce => ce.idCorporacaoEndereco == id);

            if (corporacaoEndereco == null)
            {
                return null;
            }

            _context.TB_CORPORACAO_ENDERECO.Remove(corporacaoEndereco);
            await _context.SaveChangesAsync();

            return corporacaoEndereco;
        }
        #endregion
    }
}

using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.CorporacaoEndereco
{
    public class CorporacaoEnderecoService : ICorporacaoEnderecoService
    {
        private readonly DataContext _context;
        public CorporacaoEnderecoService(DataContext context)
        {
            _context = context;
        }

        #region GET
        public async Task GetCorporacaoEnderecoAsync(int id)
        {
           var corporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO
           .FirstOrDefaultAsync(ce => ce.idCorporacaoEndereco == id);

            if (corporacaoEndereco == null)
            {
                throw new NotFoundException("Endereço de corporação não encontrado.");
            }
        }
        #endregion

        #region PUT
        public async Task PutCorporacaoEnderecoAsync(int id)
        {
             var corporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO
           .FirstOrDefaultAsync(ce => ce.idCorporacaoEndereco == id);

            if (corporacaoEndereco == null)
            {
                throw new ConflictException("Dados inválidos");
            }

            
        }
        #endregion

        #region DELETE
        public async Task DeleteCorporacaoEnderecoAsync(int id)
        {
            var existingCorporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO.FirstOrDefaultAsync(ce => ce.idCorporacaoEndereco == id);

            if (existingCorporacaoEndereco == null)
            {
                throw new NotFoundException("Endereço de corporação não encontrado.");
            }

            _context.TB_CORPORACAO_ENDERECO.Remove(existingCorporacaoEndereco);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}

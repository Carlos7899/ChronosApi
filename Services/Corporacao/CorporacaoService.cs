using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronosApi.Services.Corporacao
{
    public class CorporacaoService : ICorporacaoService
    {
        private readonly DataContext _context;
        public CorporacaoService(DataContext context)
        {
            _context = context;

        }
        #region GET
        public async Task GetCorporacaoAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);
            if (corporacao == null)
            {
                throw new NotFoundException("Corporação não encontrada.");
            }
        }
        #endregion

        #region PUT
        public async Task PutCorporacaoAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);
            if (corporacao == null)
            {
                throw new ConflictException("Dados inválidos");
            }

        }
        #endregion
       
       #region DELETE
        public async Task DeleteCorporacaoAsync(int id)
        {
          
                var existingCorporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync(c => c.idCorporacao == id);

                if (existingCorporacao == null)
                {
                    throw new NotFoundException("Corporação não encontrada.");
                }
        }
        #endregion
    }
}

using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
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
                throw new NotFoundException("Corporação não encontrada.");
            }
        }
        public async Task PutAsync(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);
            if (corporacao == null)
            {
                throw new ConflictException("Dados inválidos");
            }

        }
        public async Task DeleteAsync(int id)
        {
            var existingCorporacao = await _context.TB_CORPORACAO.FirstOrDefaultAsync((CorporacaoModel c) => c.idCorporacao == id);

            if (existingCorporacao == null)
            { 
                throw new NotFoundException("Corporação não encontrada."); 
            }
        }
    }
}

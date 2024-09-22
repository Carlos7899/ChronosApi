using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
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
            var corporacao = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);
            if (corporacao == null)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }
        }
        public async Task PutAsync(int id)
        {
            var corporacao = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);
            if (corporacao == null)
            {
                throw new ConflictException("Dados inválidos.");
            }

        }
        public async Task DeleteAsync(int id)
        {
            var existingCorporacao = await _context.TB_EGRESSO.FirstOrDefaultAsync((EgressoModel e) => e.idEgresso == id);
            if (existingCorporacao == null)
            { 
                throw new NotFoundException("Egresso não encontrado."); 
            }
        }
    }
}

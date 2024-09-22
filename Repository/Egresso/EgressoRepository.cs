using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Corporacao
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

        public async Task<ActionResult<EgressoModel>> GetIdAsync(int id)
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

            egresso.nomeEgresso = updatedEgresso.nomeEgresso;
            egresso.tipoPessoaEgresso = updatedEgresso.tipoPessoaEgresso;
            egresso.numeroEgresso = updatedEgresso.numeroEgresso;
            egresso.cpfEgresso = updatedEgresso.cpfEgresso;
            egresso.email = updatedEgresso.email;

            _context.Entry(egresso).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return egresso;
        }
            
        public async Task<ActionResult<EgressoModel>> DeleteAsync(int id)
        {

            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync(e => e.idEgresso == id);
            _context.TB_EGRESSO.Remove(egresso);
            await _context.SaveChangesAsync();

            return egresso;
        }
    }
}

using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Candidatura
{
    public class CandidaturaService : ICandidaturaService
    {
        private readonly DataContext _context;

        public CandidaturaService(DataContext context)
        {
            _context = context;
        }

        #region GET

        public async Task<CandidaturaModel> GetAsync(int id)
        {
            var candidatura = await _context.TB_CANDIDATURA.FirstOrDefaultAsync(c => c.idCandidatura == id);
            if (candidatura == null)
            {
                throw new NotFoundException("Candidatura não encontrada.");
            }

            return candidatura;
        }

        public async Task<List<CandidaturaModel>> GetAllAsync()
        {
            return await _context.TB_CANDIDATURA.ToListAsync();
        }

        public async Task<List<CandidaturaModel>> GetByEgressoAsync(int idEgresso)
        {
            return await _context.TB_CANDIDATURA.Where(c => c.idEgresso == idEgresso).ToListAsync();
        }

        public async Task<List<CandidaturaModel>> GetByVagaAsync(int idVaga)
        {
            return await _context.TB_CANDIDATURA.Where(c => c.idVaga == idVaga).ToListAsync();
        }

        public async Task<List<CandidaturaModel>> GetRecentCandidaturasByVagaAsync(int idVaga)
        {
            return await _context.TB_CANDIDATURA.Where(c => c.idVaga == idVaga).OrderByDescending(c => c.dataIncricao).ToListAsync();
        }

        public async Task<List<CandidaturaModel>> GetByCorporacaoAsync(int idCorporacao)
        {
            return await _context.TB_CANDIDATURA
                .Where(c => c.idCorporacao == idCorporacao)
                .ToListAsync();
        }

        #endregion

        #region POST (Create)

        public async Task<CandidaturaModel> CreateAsync(CandidaturaModel candidatura)
        {
            var vagaExists = await _context.TB_VAGA.AnyAsync(v => v.idVaga == candidatura.idVaga);
            if (!vagaExists)
            {
                throw new NotFoundException("Vaga não encontrada.");
            }

            var egressoExists = await _context.TB_EGRESSO.AnyAsync(e => e.idEgresso == candidatura.idEgresso);
            if (!egressoExists)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }

            var candidaturaExists = await _context.TB_CANDIDATURA.AnyAsync(c => c.idEgresso == candidatura.idEgresso && c.idVaga == candidatura.idVaga);
            if (candidaturaExists)
            {
                throw new ConflictException("Candidatura já existente para esta vaga.");
            }

            var corpExists = await _context.TB_CORPORACAO.AnyAsync(c => c.idCorporacao == candidatura.idCorporacao);
            if (!corpExists)
            {
                throw new NotFoundException("Corporação não encontrada.");
            }

            _context.TB_CANDIDATURA.Add(candidatura);
            await _context.SaveChangesAsync();

            return candidatura;
        }

        #endregion

        #region PUT (Update)

        public async Task UpdateAsync(int id, CandidaturaModel updatedCandidatura)
        {
            var candidatura = await _context.TB_CANDIDATURA.FirstOrDefaultAsync(c => c.idCandidatura == id);
            if (candidatura == null)
            {
                throw new NotFoundException("Candidatura não encontrada.");
            }

       
            var corpExists = await _context.TB_CORPORACAO.AnyAsync(c => c.idCorporacao == candidatura.idCorporacao);
            if (!corpExists)
            {
                throw new NotFoundException("Corporação associada à candidatura não encontrada.");
            }

          
            candidatura.Status = updatedCandidatura.Status;
            candidatura.DataAtualizacao = DateTime.Now;
            candidatura.Notas = updatedCandidatura.Notas;
            candidatura.Feedback = updatedCandidatura.Feedback;

            _context.TB_CANDIDATURA.Update(candidatura);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region DELETE

        public async Task DeleteAsync(int id)
        {
            var candidatura = await _context.TB_CANDIDATURA.FirstOrDefaultAsync(c => c.idCandidatura == id);
            if (candidatura == null)
            {
                throw new NotFoundException("Candidatura não encontrada.");
            }

            _context.TB_CANDIDATURA.Remove(candidatura);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region EXISTENCE CHECK

        public async Task<bool> CandidaturaExistsAsync(int id)
        {
            return await _context.TB_CANDIDATURA.AnyAsync(c => c.idCandidatura == id);
        }

        public async Task<int> CountCandidaturasByEgressoAsync(int idEgresso)
        {
            return await _context.TB_CANDIDATURA.CountAsync(c => c.idEgresso == idEgresso);
        }

        public async Task<int> CountCandidaturasByVagaAsync(int idVaga)
        {
            return await _context.TB_CANDIDATURA.CountAsync(c => c.idVaga == idVaga);
        }

        #endregion
    }
}

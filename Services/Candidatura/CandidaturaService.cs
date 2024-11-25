using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
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
            var candidatura = await _context.TB_CANDIDATURA.FindAsync(id);
            if (candidatura == null)
                throw new NotFoundException("Candidatura não encontrada.");

            return candidatura;
        }

        public async Task<List<CandidaturaModel>> GetAllAsync()
        {
            return await _context.TB_CANDIDATURA.ToListAsync();
        }

        public async Task<List<CandidaturaModel>> GetByEgressoAsync(int idEgresso)
        {
            return await _context.TB_CANDIDATURA
                .Where(c => c.idEgresso == idEgresso)
                .ToListAsync();
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
            await ValidateEgressoAndVagaExist(candidatura.idEgresso, candidatura.idVaga, candidatura.idCorporacao);

            var candidaturaExists = await _context.TB_CANDIDATURA
                .AnyAsync(c => c.idEgresso == candidatura.idEgresso && c.idVaga == candidatura.idVaga);
            if (candidaturaExists)
                throw new ConflictException("O egresso já se candidatou a esta vaga.");

            candidatura.dataIncricao = DateTime.Now;

            _context.TB_CANDIDATURA.Add(candidatura);
            await _context.SaveChangesAsync();

            return candidatura;
        }

        #endregion

        #region PUT (Update)

        public async Task UpdateAsync(int id, CandidaturaModel updatedCandidatura)
        {
            // Carrega a candidatura do banco
            var candidatura = await GetAsync(id);
            // Atualiza os campos que são permitidos alterar (status, feedback, etc.)
            candidatura.Status = updatedCandidatura.Status ?? candidatura.Status; // Permite manter o status anterior se o valor for nulo
            candidatura.Notas = updatedCandidatura.Notas ?? candidatura.Notas;  // Permite manter as notas anteriores se o valor for nulo
            candidatura.Feedback = updatedCandidatura.Feedback ?? candidatura.Feedback;  // Permite manter o feedback anterior se o valor for nulo
            candidatura.DataAtualizacao = DateTime.Now; // Atualiza a data de atualização para o momento atual

            // Atualiza a candidatura no banco de dados
            _context.TB_CANDIDATURA.Update(candidatura);
            await _context.SaveChangesAsync(); // Salva as mudanças
        }


        #endregion

        #region DELETE

        public async Task DeleteAsync(int id)
        {
            var candidatura = await GetAsync(id);

            _context.TB_CANDIDATURA.Remove(candidatura);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region AUXILIAR METHODS

        private async Task ValidateEgressoAndVagaExist(int idEgresso, int idVaga, int idCorporacao)
        {
            var egressoExists = await _context.TB_EGRESSO.AnyAsync(e => e.idEgresso == idEgresso);
            if (!egressoExists)
                throw new NotFoundException("Egresso não encontrado.");

            var vagaExists = await _context.TB_VAGA.AnyAsync(v => v.idVaga == idVaga);
            if (!vagaExists)
                throw new NotFoundException("Vaga não encontrada.");

            var corpExists = await _context.TB_CORPORACAO.AnyAsync(c => c.idCorporacao == idCorporacao);
            if (!corpExists)
                throw new NotFoundException("Corporação não encontrada.");
        }

        #endregion
    }
}
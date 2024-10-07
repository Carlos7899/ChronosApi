using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.Enderecos.Logradouro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Logradouro
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly DataContext _context;

        public LogradouroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<LogradouroModel>> GetAllAsync()
        {
            return await _context.TB_LOGRADOURO.ToListAsync();
        }

        public async Task<ActionResult<LogradouroModel>> GetIdAsync(int id)
        {
            return await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);
        }

        public async Task<ActionResult<LogradouroModel>> PostAsync(LogradouroModel logradouro)
        {
            logradouro.idLogradouro = 0; // Para garantir que o ID seja gerado pelo banco
            await _context.TB_LOGRADOURO.AddAsync(logradouro);
            await _context.SaveChangesAsync();
            return logradouro;
        }

        public async Task<ActionResult<LogradouroModel>> PutAsync(int id, LogradouroModel updatedLogradouro)
        {
            var logradouro = await _context.TB_LOGRADOURO.FindAsync(id);
            if (logradouro == null) return null;

            logradouro.cepLogradouro = updatedLogradouro.cepLogradouro;
            logradouro.tipoLogradouro = updatedLogradouro.tipoLogradouro;
            logradouro.bairroLogradouro = updatedLogradouro.bairroLogradouro;
            logradouro.cidadeLogradouro = updatedLogradouro.cidadeLogradouro;
            logradouro.ufLogradouro = updatedLogradouro.ufLogradouro;

            _context.Entry(logradouro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return logradouro;
        }

        public async Task<ActionResult<LogradouroModel>> DeleteAsync(int id)
        {
            var logradouro = await _context.TB_LOGRADOURO.FindAsync(id);
            if (logradouro == null) return null;

            _context.TB_LOGRADOURO.Remove(logradouro);
            await _context.SaveChangesAsync();
            return logradouro;
        }
    }
}

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

        #region GET
        public async Task<List<LogradouroModel>> GetAllLogradouroAsync()
        {
            var logradouros = await _context.TB_LOGRADOURO.ToListAsync();
            return logradouros;
        }

        public async Task<ActionResult<LogradouroModel>> GetIdLogradouroAsync(int id)
        {
            var logradouro = await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);
            return logradouro;
        }
        #endregion

        #region POST
        public async Task<ActionResult<LogradouroModel>> PostLogradouroAsync(LogradouroModel logradouro)
        {
            _context.TB_LOGRADOURO.Add(logradouro);
            await _context.SaveChangesAsync();
            return logradouro;
        }
        #endregion

        #region PUT
        public async Task<ActionResult<LogradouroModel>> PutLogradouroAsync(int id, LogradouroModel updatedLogradouro)
        {
            var logradouro = await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);

            if (logradouro == null)
            {
                return null;
            }

            logradouro.cepLogradouro = updatedLogradouro.cepLogradouro;
            logradouro.tipoLogradouro = updatedLogradouro.tipoLogradouro;
            logradouro.bairroLogradouro = updatedLogradouro.bairroLogradouro;
            logradouro.cidadeLogradouro = updatedLogradouro.cidadeLogradouro;
            logradouro.ufLogradouro = updatedLogradouro.ufLogradouro;

            _context.Entry(logradouro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return logradouro;
        }
        #endregion

        #region DELETE
        public async Task<ActionResult<LogradouroModel>> DeleteLogradouroAsync(int id)
        {
            var logradouro = await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);

            if (logradouro == null)
            {
                return null;
            }

            _context.TB_LOGRADOURO.Remove(logradouro);
            await _context.SaveChangesAsync();

            return logradouro;
        }
        #endregion
    }
}

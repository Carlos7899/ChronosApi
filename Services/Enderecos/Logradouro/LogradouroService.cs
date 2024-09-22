using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Logradouro
{
    public class LogradouroService : ILogradouroService
    {
        private readonly DataContext _context;
        public LogradouroService(DataContext context)
        {
            _context = context;
        }

        #region GET
        public async Task GetLogradouroAsync(int id)
        {
            var logradouro = await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);

            if (logradouro == null)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }
        }
        #endregion

        #region PUT
        public async Task PutLogradouroAsync(int id)
        {
            var logradouro = await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);

            if (logradouro == null)
            {
                throw new ConflictException("Dados inválidos");
            }

           
        }
        #endregion

        #region DELETE
        public async Task DeleteLogradouroAsync(int id)
        {
            var existingLogradouro = await _context.TB_LOGRADOURO.FirstOrDefaultAsync(l => l.idLogradouro == id);

            if (existingLogradouro == null)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }

            _context.TB_LOGRADOURO.Remove(existingLogradouro);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}

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

        public async Task GetAsync(int id)
        {
            var logradouro = await _context.TB_LOGRADOURO.FindAsync(id);
            if (logradouro == null)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }
        }

        public async Task<bool> LogradouroExisteAsync(int id)
        {
            return await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == id);
        }
    }
}

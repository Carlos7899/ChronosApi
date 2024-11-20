using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Publicacao
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly DataContext _context;

        public PublicacaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<PublicacaoModel> GetAsync(int id)
        {
            var publicacao = await _context.TB_PUBLICACAO.FirstOrDefaultAsync(p => p.idPublicacao == id);
            if (publicacao == null)
            {
                throw new NotFoundException("Publicação não encontrada.");
            }
            return publicacao;
        }

        public async Task<bool> CorporacaoExists(int id)
        {
            return await _context.TB_CORPORACAO.AnyAsync(c => c.idCorporacao == id);
        }
    }
}

using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Publicacao
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private readonly DataContext _context;

        public PublicacaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PublicacaoModel>> GetAllAsync()
        {
            return await _context.TB_PUBLICACAO .ToListAsync();
        }

        public async Task<PublicacaoModel?> GetIdAsync(int id)
        {
            return await _context.TB_PUBLICACAO.FirstOrDefaultAsync(p => p.idPublicacao == id);
        }

        public async Task<PublicacaoModel> PostAsync(PublicacaoModel publicacao)
        {
            await _context.TB_PUBLICACAO.AddAsync(publicacao);
            await _context.SaveChangesAsync();
            return publicacao;
        }

        public async Task<PublicacaoModel?> PutAsync(int id, PublicacaoModel updatedPublicacao)
        {
            var publicacao = await GetIdAsync(id);
            if (publicacao == null) return null;

            publicacao.títuloPublicacao = updatedPublicacao.títuloPublicacao;
            publicacao.conteudoPublicacao = updatedPublicacao.conteudoPublicacao;
            publicacao.avaliacaoPublicacao = updatedPublicacao.avaliacaoPublicacao;
            publicacao.idCorporacao = updatedPublicacao.idCorporacao;

            _context.Entry(publicacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return publicacao;
        }

        public async Task<PublicacaoModel?> DeleteAsync(int id)
        {
            var publicacao = await GetIdAsync(id);
            if (publicacao == null) return null;

            _context.TB_PUBLICACAO.Remove(publicacao);
            await _context.SaveChangesAsync();
            return publicacao;
        }
    }
}

using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Comentario
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly DataContext _context;

    public ComentarioRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<ComentarioModel>> GetAllAsync()
    {
        return await _context.TB_COMENTARIOS.ToListAsync();
    }

    public async Task<ComentarioModel> GetByIdAsync(int idComentario)
    {
        return await _context.TB_COMENTARIOS.FirstOrDefaultAsync(c => c.idComentario == idComentario);
    }

    public async Task AddAsync(ComentarioModel comentario)
    {
        await _context.TB_COMENTARIOS.AddAsync(comentario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ComentarioModel comentario)
    {
        _context.TB_COMENTARIOS.Update(comentario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int idComentario)
    {
        var comentario = await GetByIdAsync(idComentario);
        if (comentario != null)
        {
            _context.TB_COMENTARIOS.Remove(comentario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ComentarioModel>> GetByPublicacaoIdAsync(int idPublicacao)
    {
        return await _context.TB_COMENTARIOS
            .Where(c => c.idPublicacao == idPublicacao)
            .ToListAsync();
    }
}
}

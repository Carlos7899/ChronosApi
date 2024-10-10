using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Comentario
{
    public class ComentarioService : IComentarioService
    {
        private readonly DataContext _context;

        public ComentarioService(DataContext context)
        {
            _context = context;
        }

        public async Task AdicionarComentarioAsync(ComentarioModel comentario)
        {
            var resultadoValidacao = await ValidarPublicacaoOuEgresso(comentario.idPublicacao, comentario.idEgresso);
            if (resultadoValidacao != "Válido")
            {
                throw new ConflictException(resultadoValidacao);
            }

            _context.TB_COMENTARIOS.Add(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarComentarioAsync(int idComentario, ComentarioModel comentarioAtualizado)
        {
            var existingComentario = await _context.TB_COMENTARIOS.FindAsync(idComentario);
            if (existingComentario == null)
            {
                throw new NotFoundException("Comentário não encontrado.");
            }

          
            existingComentario.comentarioPublicacao = comentarioAtualizado.comentarioPublicacao;

            _context.TB_COMENTARIOS.Update(existingComentario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ComentarioModel>> ObterComentariosPorPublicacaoAsync(int idPublicacao)
        {
            return await _context.TB_COMENTARIOS
                .Where(c => c.idPublicacao == idPublicacao)
                .ToListAsync();
        }

        public async Task<ComentarioModel?> ObterComentarioPorIdAsync(int idComentario)
        {
            return await _context.TB_COMENTARIOS.FirstOrDefaultAsync(c => c.idComentario == idComentario);
        }

        public async Task<string> ValidarPublicacaoOuEgresso(int idPublicacao, int idEgresso)
        {
            var publicacaoExiste = await _context.TB_PUBLICACAO.AnyAsync(p => p.idPublicacao == idPublicacao);
            var egressoExiste = await _context.TB_EGRESSO.AnyAsync(e => e.idEgresso == idEgresso);

            if (!publicacaoExiste && !egressoExiste)
            {
                return "Publicação e Egresso não encontrados.";
            }
            else if (!publicacaoExiste)
            {
                return "Publicação não encontrada.";
            }
            else if (!egressoExiste)
            {
                return "Egresso não encontrado.";
            }

            return "Válido";
        }

    }
}
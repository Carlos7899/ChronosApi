using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Curso
{
    public class CursoService : ICursoService
    {

        private readonly DataContext _context;

        public CursoService(DataContext context)
        {
            _context = context;
        }

        public async Task<CursoModel> GetAsync(int id)
        {
            var curso = await _context.TB_CURSO.FirstOrDefaultAsync(c => c.idCurso == id);
            if (curso == null)
            {
                throw new NotFoundException("Curso não encontrado.");
            }
            return curso;
        }

        public async Task PutAsync(int id, CursoModel cursoAtualizado)
        {
            var curso = await _context.TB_CURSO.FirstOrDefaultAsync(c => c.idCurso == id);
            if (curso == null)
            {
                throw new NotFoundException("Curso não encontrado.");
            }

            curso.nomeCurso = cursoAtualizado.nomeCurso;
            curso.descricaoCurso = cursoAtualizado.descricaoCurso;
            curso.cargaHorariaCurso = cursoAtualizado.cargaHorariaCurso;
            curso.dataInicioCurso = cursoAtualizado.dataInicioCurso;
            curso.dataFimCurso = cursoAtualizado.dataFimCurso;
            curso.limiteVagas = cursoAtualizado.limiteVagas;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var curso = await _context.TB_CURSO.FirstOrDefaultAsync(c => c.idCurso == id);
            if (curso == null)
            {
                throw new NotFoundException("Curso não encontrado.");
            }

            _context.TB_CURSO.Remove(curso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CursoExisteAsync(int id)
        {
            return await _context.TB_CURSO.AnyAsync(c => c.idCurso == id);
        }

        public async Task CreateAsync(CursoModel novoCurso)
        {
           
            _context.TB_CURSO.Add(novoCurso);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CursoModel>> GetAllAsync()
        {
            return await _context.TB_CURSO.ToListAsync();
        }

        public async Task<IEnumerable<CursoModel>> GetCursosByCorporacaoAsync(int idCorporacao)
        {
            return await _context.TB_CURSO.Where(c => c.idCorporacao == idCorporacao).ToListAsync();
        }

        public async Task<IEnumerable<CursoModel>> GetCursosByNomeAsync(string nomeCurso)
        {
            return await _context.TB_CURSO.Where(c => c.nomeCurso.Contains(nomeCurso)).ToListAsync();
        }

        public async Task<int> ContarCursosPorCorporacaoAsync(int idCorporacao)
        {
            return await _context.TB_CURSO.CountAsync(c => c.idCorporacao == idCorporacao);
        }
    }
}

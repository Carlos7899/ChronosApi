using ChronosApi.Data;
using ChronosApi.Models.Curriculo;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Curriculo.Experiencia
{
    public class ExperienciaService : IExperienciaService
    {
        private readonly DataContext _context;

        public ExperienciaService(DataContext context)
        {
            _context = context;
        }

        public async Task<ExperienciaModel> GetAsync(int id)
        {
            var experiencia = await _context.TB_EXPERIENCIA.FirstOrDefaultAsync(e => e.idExperiencia == id);
            if (experiencia == null)
            {
                throw new NotFoundException("Experiência não encontrada.");
            }
            return experiencia;
        }

        public async Task PutAsync(int id, ExperienciaModel experienciaAtualizada)
        {
            var experiencia = await _context.TB_EXPERIENCIA.FirstOrDefaultAsync(e => e.idExperiencia == id);
            if (experiencia == null)
            {
                throw new NotFoundException("Experiência não encontrada.");
            }

            experiencia.empresaExperiencia = experienciaAtualizada.empresaExperiencia;
            experiencia.cargoExperiencia = experienciaAtualizada.cargoExperiencia;
            experiencia.dataInicioExperiencia = experienciaAtualizada.dataInicioExperiencia;
            experiencia.dataFimExperiencia = experienciaAtualizada.dataFimExperiencia;
            experiencia.Descricao = experienciaAtualizada.Descricao;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var experiencia = await _context.TB_EXPERIENCIA.FirstOrDefaultAsync(e => e.idExperiencia == id);
            if (experiencia == null)
            {
                throw new NotFoundException("Experiência não encontrada.");
            }

            _context.TB_EXPERIENCIA.Remove(experiencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExperienciaExisteAsync(int id)
        {
            return await _context.TB_EXPERIENCIA.AnyAsync(e => e.idExperiencia == id);
        }

        public async Task CreateAsync(ExperienciaModel novaExperiencia)
        {
       
            await _context.TB_EXPERIENCIA.AddAsync(novaExperiencia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExperienciaModel>> GetAllAsync()
        {
            return await _context.TB_EXPERIENCIA.ToListAsync();
        }

        public async Task<IEnumerable<ExperienciaModel>> GetExperienciasByCurriculoAsync(int idCurriculo)
        {
            return await _context.TB_EXPERIENCIA
                .Where(e => e.idCurriculo == idCurriculo)
                .ToListAsync();
        }
    }
}
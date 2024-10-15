using ChronosApi.Data;
using ChronosApi.Models.Curriculo;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Curriculo.Curriculo
{
    public class CurriculoService : ICurriculoService
    {
        private readonly DataContext _context;

        public CurriculoService(DataContext context)
        {
            _context = context;
        }

        
        public async Task<CurriculoModel> GetAsync(int id)
        {
            var curriculo = await _context.TB_CURRICULO.FirstOrDefaultAsync(c => c.idCurriculo == id);
            if (curriculo == null)
            {
                throw new NotFoundException("Currículo não encontrado.");
            }
            return curriculo;
        }

        
        public async Task PutAsync(int id, CurriculoModel curriculoAtualizado)
        {
            var curriculo = await _context.TB_CURRICULO.FirstOrDefaultAsync(c => c.idCurriculo == id);
            if (curriculo == null)
            {
                throw new NotFoundException("Currículo não encontrado.");
            }

         
            curriculo.emailCurriculo = curriculoAtualizado.emailCurriculo;
            curriculo.telefoneCurriculo = curriculoAtualizado.telefoneCurriculo;
            curriculo.habilidadesCurriculo = curriculoAtualizado.habilidadesCurriculo;
            curriculo.descricaoCurriculo = curriculoAtualizado.descricaoCurriculo;

            await _context.SaveChangesAsync();
        }

      
        public async Task DeleteAsync(int id)
        {
            var curriculo = await _context.TB_CURRICULO.FirstOrDefaultAsync(c => c.idCurriculo == id);
            if (curriculo == null)
            {
                throw new NotFoundException("Currículo não encontrado.");
            }

            _context.TB_CURRICULO.Remove(curriculo);
            await _context.SaveChangesAsync();
        }

       
        public async Task<bool> CurriculoExisteAsync(int id)
        {
            return await _context.TB_CURRICULO.AnyAsync(c => c.idCurriculo == id);
        }

      
        public async Task CreateAsync(CurriculoModel novoCurriculo)
        {
            if (novoCurriculo == null)
            {
                throw new ArgumentNullException(nameof(novoCurriculo), "O currículo não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(novoCurriculo.emailCurriculo))
            {
                throw new ArgumentException("O e-mail do currículo não pode estar vazio.", nameof(novoCurriculo.emailCurriculo));
            }

            if (string.IsNullOrWhiteSpace(novoCurriculo.telefoneCurriculo))
            {
                throw new ArgumentException("O telefone do currículo não pode estar vazio.", nameof(novoCurriculo.telefoneCurriculo));
            }

            if (string.IsNullOrWhiteSpace(novoCurriculo.habilidadesCurriculo))
            {
                throw new ArgumentException("As habilidades do currículo não podem estar vazias.", nameof(novoCurriculo.habilidadesCurriculo));
            }

            if (string.IsNullOrWhiteSpace(novoCurriculo.descricaoCurriculo))
            {
                throw new ArgumentException("A descrição do currículo não pode estar vazia.", nameof(novoCurriculo.descricaoCurriculo));
            }

            _context.TB_CURRICULO.Add(novoCurriculo);
            await _context.SaveChangesAsync();
        }

       
        public async Task<IEnumerable<CurriculoModel>> GetAllAsync()
        {
            return await _context.TB_CURRICULO.ToListAsync();
        }

        
        public async Task<IEnumerable<CurriculoModel>> GetCurriculosByEgressoAsync(int idEgresso)
        {
            return await _context.TB_CURRICULO
                .Where(c => c.idEgresso == idEgresso)
                .ToListAsync();
        }
    }
}
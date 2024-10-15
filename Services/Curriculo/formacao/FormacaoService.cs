using ChronosApi.Data;
using ChronosApi.Models.Curriculo;
using ChronosApi.Services.Curriculo.formacao;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Formacao
{
    public class FormacaoService : IFormacaoService
    {
        private readonly DataContext _context;

        public FormacaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<FormacaoModel> GetAsync(int id)
        {
            var formacao = await _context.TB_FORMACAO.FirstOrDefaultAsync(f => f.idFormacao == id);
            if (formacao == null)
            {
                throw new NotFoundException("Formação não encontrada.");
            }
            return formacao;
        }

        public async Task<IEnumerable<FormacaoModel>> GetAllAsync()
        {
            return await _context.TB_FORMACAO.ToListAsync();
        }

        public async Task<IEnumerable<FormacaoModel>> GetFormacoesByCurriculoAsync(int idCurriculo)
        {
            return await _context.TB_FORMACAO
                .Where(f => f.idCurriculo == idCurriculo)
                .ToListAsync();
        }

        public async Task CreateAsync(FormacaoModel novaFormacao)
        {
            // Validações
            if (novaFormacao == null)
            {
                throw new ArgumentNullException(nameof(novaFormacao), "A formação não pode ser nula.");
            }

            if (string.IsNullOrWhiteSpace(novaFormacao.cursoFormacao))
            {
                throw new ArgumentException("O curso da formação não pode estar vazio.", nameof(novaFormacao.cursoFormacao));
            }

            if (string.IsNullOrWhiteSpace(novaFormacao.instituicaoFormacao))
            {
                throw new ArgumentException("A instituição da formação não pode estar vazia.", nameof(novaFormacao.instituicaoFormacao));
            }

            if (novaFormacao.dataConclusaoFormacao == default)
            {
                throw new ArgumentException("A data de conclusão da formação deve ser válida.", nameof(novaFormacao.dataConclusaoFormacao));
            }

            await _context.TB_FORMACAO.AddAsync(novaFormacao);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(int id, FormacaoModel formacaoAtualizada)
        {
            var formacao = await _context.TB_FORMACAO.FirstOrDefaultAsync(f => f.idFormacao == id);
            if (formacao == null)
            {
                throw new NotFoundException("Formação não encontrada.");
            }

            // Atualiza as propriedades da formação
            formacao.cursoFormacao = formacaoAtualizada.cursoFormacao;
            formacao.instituicaoFormacao = formacaoAtualizada.instituicaoFormacao;
            formacao.dataConclusaoFormacao = formacaoAtualizada.dataConclusaoFormacao;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var formacao = await _context.TB_FORMACAO.FirstOrDefaultAsync(f => f.idFormacao == id);
            if (formacao == null)
            {
                throw new NotFoundException("Formação não encontrada.");
            }

            _context.TB_FORMACAO.Remove(formacao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FormacaoExisteAsync(int id)
        {
            return await _context.TB_FORMACAO.AnyAsync(f => f.idFormacao == id);
        }
    }
}

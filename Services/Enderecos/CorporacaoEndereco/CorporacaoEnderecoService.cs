using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.CorporacaoEndereco
{
    public class CorporacaoEnderecoService : ICorporacaoEnderecoService
    {
        private readonly DataContext _context;
        public CorporacaoEnderecoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CorporacaoEnderecoModel>> GetAllCorporacoesEnderecosAsync()
        {
            return await _context.TB_CORPORACAO_ENDERECO.Include(e => e.logradouro).ToListAsync();
        }

        public async Task<CorporacaoEnderecoModel> GetCorporacaoEnderecoAsync(int id)
        {
            var endereco = await _context.TB_CORPORACAO_ENDERECO.Include(e => e.logradouro).FirstOrDefaultAsync(e => e.idCorporacaoEndereco == id);

            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }

            return endereco;
        }

        public async Task<CorporacaoEnderecoModel> CreateCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco)
        {
            var corporacaoExists = await _context.TB_CORPORACAO.AnyAsync(c => c.idCorporacao == endereco.idCorporacao);
            if (!corporacaoExists)
            {
                throw new NotFoundException("Corporação não encontrada.");
            }

            var logradouroExists = await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == endereco.idLogradouro);
            if (!logradouroExists)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }

            return endereco;
        }

        public async Task<CorporacaoEnderecoModel> UpdateCorporacaoEnderecoAsync(int id, CorporacaoEnderecoModel updatedEndereco)
        {
            var endereco = await GetCorporacaoEnderecoAsync(id);

            endereco.numeroCorporacaoEndereco = updatedEndereco.numeroCorporacaoEndereco;
            endereco.complementoCorporacaoEndereco = updatedEndereco.complementoCorporacaoEndereco;

            return endereco;
        }

        public async Task DeleteCorporacaoEnderecoAsync(int id)
        {
            var existingEndereco = await _context.TB_CORPORACAO_ENDERECO.FirstOrDefaultAsync(e => e.idCorporacaoEndereco == id);
            if (existingEndereco == null)
            {
                throw new NotFoundException("Corporação não encontrada.");
            }
        }
    }
}
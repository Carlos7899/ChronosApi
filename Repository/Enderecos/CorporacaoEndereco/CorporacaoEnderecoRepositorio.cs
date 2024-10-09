using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.CorporacaoEndereco
{
    public class CorporacaoEnderecoRepository : ICorporacaoEnderecoRepository
    {
        private readonly DataContext _context;
        public CorporacaoEnderecoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CorporacaoEnderecoModel?> GetCorporacaoEnderecoByIdAsync(int id)
        {
            return await _context.TB_CORPORACAO_ENDERECO.Include(e => e.Logradouro)
                .FirstOrDefaultAsync(e => e.idCorporacaoEndereco == id);
        }

        public async Task<bool> CorporacaoExistsAsync(int idCorporacao)
        {
            return await _context.TB_CORPORACAO.AnyAsync(e => e.idCorporacao == idCorporacao);
        }

        public async Task<bool> LogradouroExistsAsync(int idLogradouro)
        {
            return await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == idLogradouro);
        }

        public async Task<CorporacaoEnderecoModel> AddCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco)
        {
            _context.TB_CORPORACAO_ENDERECO.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<CorporacaoEnderecoModel> UpdateCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task DeleteCorporacaoEnderecoAsync(CorporacaoEnderecoModel endereco)
        {
            _context.TB_CORPORACAO_ENDERECO.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
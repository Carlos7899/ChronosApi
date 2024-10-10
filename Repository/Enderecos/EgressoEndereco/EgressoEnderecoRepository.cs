using ChronosApi.Data;
using Microsoft.EntityFrameworkCore;
using ChronosApi.Models.Enderecos;

namespace ChronosApi.Repository.Enderecos.EgressoEndereco
{
    public class EgressoEnderecoRepository : IEgressoEnderecoRepository
    {

        private readonly DataContext _context;
        public EgressoEnderecoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EgressoEnderecoModel?> GetEgressoEnderecoByIdAsync(int id)
        {
            return await _context.TB_EGRESSO_ENDERECO.Include(e => e.Logradouro)
                .FirstOrDefaultAsync(e => e.idEgressoEndereco == id);
        }

        public async Task<bool> EgressoExistsAsync(int idEgresso)
        {
            return await _context.TB_EGRESSO.AnyAsync(e => e.idEgresso == idEgresso);
        }

        public async Task<bool> LogradouroExistsAsync(int idLogradouro)
        {
            return await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == idLogradouro);
        }

        public async Task<EgressoEnderecoModel> AddEgressoEnderecoAsync(EgressoEnderecoModel endereco)
        {
            _context.TB_EGRESSO_ENDERECO.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<EgressoEnderecoModel> UpdateEgressoEnderecoAsync(EgressoEnderecoModel endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task DeleteEgressoEnderecoAsync(EgressoEnderecoModel endereco)
        {
            _context.TB_EGRESSO_ENDERECO.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}

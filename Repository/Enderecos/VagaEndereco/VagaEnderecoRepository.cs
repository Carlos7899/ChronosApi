using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Repository.CorporacaoEndereco;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Enderecos.VagaEndereco
{
    public class VagaEnderecoRepository : IVagaEnderecoRepository
    {
        private readonly DataContext _context;
        public VagaEnderecoRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<VagaEnderecoModel?> GetVagaEnderecoByIdAsync(int id)
        {
            return await _context.TB_VAGA_ENDERECO.Include(e => e.logradouro).FirstOrDefaultAsync(e => e.idVagaEndereco == id);
        }

        public async Task<bool> VagaExistsAsync(int idvaga)
        {
            return await _context.TB_VAGA.AnyAsync(e => e.idVaga == idvaga);
        }

        public async Task<bool> LogradouroExistsAsync(int idLogradouro)
        {
            return await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == idLogradouro);
        }

        public async Task<VagaEnderecoModel> AddVagaEnderecoAsync(VagaEnderecoModel endereco)
        {
            _context.TB_VAGA_ENDERECO.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<VagaEnderecoModel> UpdateVagaEnderecoAsync(VagaEnderecoModel endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task DeleteVagaEnderecoAsync(VagaEnderecoModel endereco)
        {
            _context.TB_VAGA_ENDERECO.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
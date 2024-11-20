using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Enderecos.VagaEndereco
{
    public class VagaEnderecoService : IVagaEnderecoService
    {
        private readonly DataContext _context;

        public VagaEnderecoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VagaEnderecoModel>> GetAllVagasEnderecosAsync()
        {
            return await _context.TB_VAGA_ENDERECO.Include(e => e.logradouro).ToListAsync();
        }

        public async Task<VagaEnderecoModel> GetVagaEnderecoAsync(int id)
        {
            var endereco = await _context.TB_VAGA_ENDERECO.Include(e => e.logradouro).FirstOrDefaultAsync(e => e.idVagaEndereco == id);
            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }

            return endereco;
        }

        public async Task<VagaEnderecoModel> CreateVagaEnderecoAsync(VagaEnderecoModel endereco)
        {
            var vagaExists = await _context.TB_VAGA.AnyAsync(c => c.idVaga == endereco.idVaga);
            if (!vagaExists)
            {
                throw new NotFoundException("Vaga não encontrada.");
            }

            var logradouroExists = await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == endereco.idLogradouro);
            if (!logradouroExists)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }

            return endereco;
        }

        public async Task<VagaEnderecoModel> UpdateVagaEnderecoAsync(int id, VagaEnderecoModel updatedEndereco)
        {
            var endereco = await GetVagaEnderecoAsync(id);

            endereco.numeroVagaEndereco = updatedEndereco.numeroVagaEndereco;
            endereco.complementoVagaEndereco = updatedEndereco.complementoVagaEndereco;

            return endereco;
        }

        public async Task DeleteVagaEnderecoAsync(int id)
        {
            var existingEndereco = await _context.TB_VAGA_ENDERECO.FirstOrDefaultAsync(e => e.idVagaEndereco == id);
            if (existingEndereco == null)
            {
                throw new NotFoundException("Vaga não encontrada.");
            }
        }
    }
}

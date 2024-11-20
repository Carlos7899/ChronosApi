using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.EgressoEndereco
{
    public class EgressoEnderecoService : IEgressoEnderecoService
    {
        private readonly DataContext _context;

        public EgressoEnderecoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EgressoEnderecoModel>> GetAllEgressosEnderecosAsync()
        {
            return await _context.TB_EGRESSO_ENDERECO.Include(e => e.Logradouro).ToListAsync();
        }

        public async Task<EgressoEnderecoModel> GetEgressoEnderecoAsync(int id)
        {
            var endereco = await _context.TB_EGRESSO_ENDERECO.Include(e => e.Logradouro).FirstOrDefaultAsync(e => e.idEgressoEndereco == id);

            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }

            return endereco;
        }

        public async Task<EgressoEnderecoModel> CreateEgressoEnderecoAsync(EgressoEnderecoModel endereco)
        {
            var egressoExists = await _context.TB_EGRESSO.AnyAsync(e => e.idEgresso == endereco.idEgresso);
            if (!egressoExists)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }

            var logradouroExists = await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == endereco.idLogradouro);
            if (!logradouroExists)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }

            return endereco;
        }

        public async Task<EgressoEnderecoModel> UpdateEgressoEnderecoAsync(int id, EgressoEnderecoModel updatedEndereco)
        {
            var endereco = await GetEgressoEnderecoAsync(id);

            endereco.numeroEgressoEndereco = updatedEndereco.numeroEgressoEndereco;
            endereco.complementoEgressoEndereco = updatedEndereco.complementoEgressoEndereco;

            return endereco;
        }

        public async Task DeleteEgressoEnderecoAsync(int id)
        {
            var existingEndereco = await _context.TB_EGRESSO_ENDERECO.FirstOrDefaultAsync((EgressoEnderecoModel e) => e.idEgressoEndereco == id);
            if (existingEndereco == null)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }
        }
    }
}

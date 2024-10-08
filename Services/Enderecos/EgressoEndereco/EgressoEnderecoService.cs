
using ChronosApi.Data;
using ChronosApi.Models;
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


        public async Task<EgressoEnderecoModel> GetAsync(int id)
        {
            var endereco = await _context.TB_EGRESSO_ENDERECO
                .Include(e => e.Egresso)
                .Include(e => e.Logradouro)
                .FirstOrDefaultAsync(e => e.idEgressoEndereco == id);
            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }
            return endereco;
        }

        public async Task<List<EgressoEnderecoModel>> GetAllAsync()
        {
            return await _context.TB_EGRESSO_ENDERECO
                .Include(e => e.Egresso)
                .Include(e => e.Logradouro)
                .ToListAsync();
        }

        public async Task<EgressoEnderecoModel> CreateAsync(EgressoEnderecoModel endereco)
        {
            await _context.TB_EGRESSO_ENDERECO.AddAsync(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<EgressoEnderecoModel> UpdateAsync(int id, EgressoEnderecoModel updatedEndereco)
        {
            var endereco = await GetAsync(id);
            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }

            endereco.idLogradouro = updatedEndereco.idLogradouro;
            endereco.idEgresso = updatedEndereco.idEgresso;
            endereco.numeroEgressoEndereco = updatedEndereco.numeroEgressoEndereco;
            endereco.complementoEgressoEndereco = updatedEndereco.complementoEgressoEndereco;

            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task DeleteAsync(int id)
        {
            var endereco = await GetAsync(id);
            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }

            _context.TB_EGRESSO_ENDERECO.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
    
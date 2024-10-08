using ChronosApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChronosApi.Models.Enderecos;

namespace ChronosApi.Repository.Enderecos.EgressoEndereco
{
    public class EgressoEnderecoRepositorio : IEgressoEnderecoRepositorio
    {

        private readonly DataContext _context;
        public EgressoEnderecoRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EgressoEnderecoModel>> GetAllAsync()
        {
            return await _context.TB_EGRESSO_ENDERECO
                .Include(e => e.Egresso)
                .Include(e => e.Logradouro)
                .ToListAsync();
        }

        public async Task<EgressoEnderecoModel> GetIdAsync(int id)
        {
            return await _context.TB_EGRESSO_ENDERECO
                .Include(e => e.Egresso)
                .Include(e => e.Logradouro)
                .FirstOrDefaultAsync(e => e.idEgressoEndereco == id);
        }

        public async Task<EgressoEnderecoModel> PostAsync(EgressoEnderecoModel endereco)
        {
            _context.TB_EGRESSO_ENDERECO.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<EgressoEnderecoModel> PutAsync(int id, EgressoEnderecoModel updatedEndereco)
        {
            var endereco = await GetIdAsync(id);
            if (endereco == null)
            {
                return null;
            }

            endereco.idLogradouro = updatedEndereco.idLogradouro;
            endereco.idEgresso = updatedEndereco.idEgresso;
            endereco.numeroEgressoEndereco = updatedEndereco.numeroEgressoEndereco;
            endereco.complementoEgressoEndereco = updatedEndereco.complementoEgressoEndereco;

            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<EgressoEnderecoModel> DeleteAsync(int id)
        {
            var endereco = await GetIdAsync(id);
            if (endereco != null)
            {
                _context.TB_EGRESSO_ENDERECO.Remove(endereco);
                await _context.SaveChangesAsync();
                return endereco;
            }
            return null;
        }
    }
}
 

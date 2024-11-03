using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Vaga
{
    public class VagaRepository : IVagaRepository
    {
        private readonly DataContext _context;

        public VagaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<VagaModel>> GetAllAsync()
        {
            return await _context.TB_VAGA .ToListAsync();
        }

        public async Task<VagaModel?> GetIdAsync(int id)
        {
            return await _context.TB_VAGA.FirstOrDefaultAsync(v => v.idVaga == id);
        }

        public async Task<VagaModel> PostAsync(VagaModel vaga)
        {
            // Adiciona a nova vaga ao contexto
            await _context.TB_VAGA.AddAsync(vaga); // _context é seu DbContext
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return vaga; // Retorna a vaga criada
        }


        public async Task<VagaModel?> PutAsync(int id, VagaModel updatedVaga)
        {
            var vaga = await GetIdAsync(id);
            if (vaga == null) return null;

            vaga.nomeVaga = updatedVaga.nomeVaga;
            vaga.nomeVaga = updatedVaga.nomeVaga;
            vaga.descricaoVaga = updatedVaga.descricaoVaga;
            vaga.responsabilidadesVaga = updatedVaga.responsabilidadesVaga;
            vaga.salarioVaga = updatedVaga.salarioVaga;
            vaga.cidadeVaga = updatedVaga.cidadeVaga;
            vaga.beneficiosVaga = updatedVaga.beneficiosVaga;

            _context.Entry(vaga).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vaga;
        }

        public async Task<VagaModel?> DeleteAsync(int id)
        {
            var vaga = await GetIdAsync(id);
            if (vaga == null) return null;

            _context.TB_VAGA.Remove(vaga);
            await _context.SaveChangesAsync();
            return vaga;
        }
    }
}

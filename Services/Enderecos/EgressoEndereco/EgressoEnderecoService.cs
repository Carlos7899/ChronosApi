
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


        #region GET
        public async Task<List<EgressoEnderecoModel>> GetAllEgressoEnderecosAsync()
        {
            return await _context.TB_EGRESSO_ENDERECO.Include(ee => ee.Egresso).ToListAsync();
        }

        public async Task<EgressoEnderecoModel> GetEgressoEnderecoByIdAsync(int id)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO
                .Include(ee => ee.Egresso)
                .FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (egressoEndereco == null)
            {
                throw new NotFoundException("Endereço do egresso não encontrado.");
            }

            return egressoEndereco;
        }
        #endregion

        #region POST
        public async Task<EgressoEnderecoModel> CreateEgressoEnderecoAsync(EgressoEnderecoModel egressoEndereco)
        {
            var egresso = await _context.TB_EGRESSO.FirstOrDefaultAsync(e => e.idEgresso == egressoEndereco.idEgresso);
            if (egresso == null)
            {
                throw new NotFoundException("Egresso não encontrado.");
            }

            await _context.TB_EGRESSO_ENDERECO.AddAsync(egressoEndereco);
            await _context.SaveChangesAsync();

            // Aqui, você pode retornar o Egresso junto com o EgressoEndereco
            egressoEndereco.Egresso = egresso; // Associando os dados do egresso ao endereço

            return egressoEndereco;
        }
        #endregion

        #region PUT
        public async Task<EgressoEnderecoModel> PutEgressoEnderecoAsync(int id, EgressoEnderecoModel updatedEgressoEndereco)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO.FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (egressoEndereco == null)
            {
                throw new ConflictException("Endereço do egresso não encontrado.");
            }

            egressoEndereco.numeroEgressoEndereco = updatedEgressoEndereco.numeroEgressoEndereco;
            egressoEndereco.complementoEgressoEndereco = updatedEgressoEndereco.complementoEgressoEndereco;

            _context.Entry(egressoEndereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return egressoEndereco;
        }
        #endregion

        #region DELETE TEMP
        public async Task DeleteEgressoEnderecoAsync(int id)
        {
            var existingEgressoEndereco = await _context.TB_EGRESSO_ENDERECO.FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (existingEgressoEndereco == null)
            {
                throw new NotFoundException("Endereço do egresso não encontrado.");
            }

            _context.TB_EGRESSO_ENDERECO.Remove(existingEgressoEndereco);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
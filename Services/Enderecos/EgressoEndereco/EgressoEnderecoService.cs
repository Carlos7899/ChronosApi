/*
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

        #region GET
        public async Task<EgressoEndereco> GetEgressoEnderecoAsync(int id)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO
                .FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (egressoEndereco == null)
            {
                throw new NotFoundException("Endereço de egresso não encontrado.");
            }
            return egressoEndereco;
        }
        #endregion

        #region PUT
        public async Task UpdateEgressoEnderecoAsync(int id, EgressoEndereco updatedEndereco)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO
                .FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (egressoEndereco == null)
            {
                throw new NotFoundException("Endereço de egresso não encontrado.");
            }

            egressoEndereco.Endereco = updatedEndereco.Endereco; // ajuste conforme as propriedades
            await _context.SaveChangesAsync();
        }
        #endregion

        #region DELETE
        public async Task DeleteEgressoEnderecoAsync(int id)
        {
            var existingEgressoEndereco = await _context.TB_EGRESSO_ENDERECO
                .FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (existingEgressoEndereco == null)
            {
                throw new NotFoundException("Endereço de egresso não encontrado.");
            }

            _context.TB_EGRESSO_ENDERECO.Remove(existingEgressoEndereco);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
*/
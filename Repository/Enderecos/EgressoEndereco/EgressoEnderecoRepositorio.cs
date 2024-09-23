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

        #region GET
        public async Task<List<EgressoEnderecoModel>> GetAllEgressoEnderecoAsync()
        {
            var egressoEnderecos = await _context.TB_EGRESSO_ENDERECO.ToListAsync();
            return egressoEnderecos;
        }

        public async Task<ActionResult<EgressoEnderecoModel>> GetIdEgressoEnderecoAsync(int id)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO.FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);
            return egressoEndereco;
        }
        #endregion

        #region POST
        public async Task<ActionResult<EgressoEnderecoModel>> PostEgressoEnderecoAsync(EgressoEnderecoModel egressoEndereco)
        {
            _context.TB_EGRESSO_ENDERECO.Add(egressoEndereco);
            await _context.SaveChangesAsync();
            return egressoEndereco;
        }
        #endregion

        #region PUT
        public async Task<ActionResult<EgressoEnderecoModel>> PutEgressoEnderecoAsync(int id, EgressoEnderecoModel updatedEgressoEndereco)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO.FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (egressoEndereco == null)
            {
                return null;
            }

            egressoEndereco.numeroEgressoEndereco = updatedEgressoEndereco.numeroEgressoEndereco;
            egressoEndereco.complementoEgressoEndereco = updatedEgressoEndereco.complementoEgressoEndereco;

            _context.Entry(egressoEndereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return egressoEndereco;
        }
        #endregion

        #region DELETE        
        public async Task<ActionResult<EgressoEnderecoModel>> DeleteEgressoEnderecoAsync(int id)
        {
            var egressoEndereco = await _context.TB_EGRESSO_ENDERECO.FirstOrDefaultAsync(ee => ee.idEgressoEndereco == id);

            if (egressoEndereco == null)
            {
                return null;
            }

            _context.TB_EGRESSO_ENDERECO.Remove(egressoEndereco);
            await _context.SaveChangesAsync();

            return egressoEndereco;
        }
        #endregion
    }
}
 

using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Egresso
{
    public interface IEgressoRepository
    {
        public Task<List<EgressoModel>> GetAllAsync();
        public Task<ActionResult<EgressoModel>> GetIdAsync(int id);
        public Task<ActionResult<EgressoModel>> PutAsync(int id, EgressoModel updatedEgresso);
        public Task<ActionResult<EgressoModel>> PostAsync(EgressoModel egresso);
        public Task<ActionResult<EgressoModel>> DeleteAsync(int id);
    }
}

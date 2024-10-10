using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Repository.Egresso
{
    public interface IEgressoRepository
    {
        public Task<List<EgressoModel>> GetAllAsync();
        public Task<ActionResult<EgressoModel?>> GetIdAsync(int id);
        public Task<ActionResult<EgressoModel>> PutAsync(int id, EgressoModel updatedEgresso);
        public Task<ActionResult<EgressoModel>> PostAsync(EgressoModel egresso);
        public Task<ActionResult<EgressoModel>> DeleteAsync(int id);
        public Task RegistrarEgressoAsync(string email, string passwordString);
        public Task<bool> AutenticarEgressoAsync(string email, string passwordString);
        public Task AlterarSenhaEgressoAsync(string email, string novaSenha);
    }
}

namespace ChronosApi.Services.Egresso
{
    public interface IEgressoService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
        public Task RegistrarEgressoExistente(string email);
        public Task<string> AutenticarEgressoAsync(string email, string passwordString);
        public Task GetEgressoAsync(string email);
        public Task<bool> EgressoExisteAsync(int id);
    }
}

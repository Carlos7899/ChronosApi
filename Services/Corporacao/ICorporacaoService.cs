namespace ChronosApi.Services.Corporacao
{
    public interface ICorporacaoService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
        public Task RegistrarCorporacaoExistente(string email);
        public Task<String> AutenticarCorporacaoAsync(string email, string passwordString);
        public Task GetCorporacaoAsync(string email);
        public Task<bool> CorporacaoExisteAsync(int id);
    }
}

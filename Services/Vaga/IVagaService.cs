namespace ChronosApi.Services.Vaga
{
    public interface IVagaService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
        public Task<bool> VagaExisteAsync(int id);
    }
}

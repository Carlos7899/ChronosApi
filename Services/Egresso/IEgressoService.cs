namespace ChronosApi.Services.Egresso
{
    public interface IEgressoService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
    }
}

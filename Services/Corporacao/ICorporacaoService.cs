namespace ChronosApi.Services.Corporacao
{
    public interface ICorporacaoService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
    }
}

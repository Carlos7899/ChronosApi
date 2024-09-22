namespace ChronosApi.Services.Corporacao
{
    public interface ICorporacaoService
    {
        public Task GetCorporacaoAsync(int id);
        public Task PutCorporacaoAsync(int id);
        public Task DeleteCorporacaoAsync(int id);
    }
}

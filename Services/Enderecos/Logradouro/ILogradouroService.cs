namespace ChronosApi.Services.Logradouro
{
    public interface ILogradouroService
    {
        Task GetAsync(int id);
        Task<bool> LogradouroExisteAsync(int id);
    }
}

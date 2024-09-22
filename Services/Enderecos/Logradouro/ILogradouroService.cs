using System.Threading.Tasks;

namespace ChronosApi.Services.Logradouro
{
    public interface ILogradouroService
    {
        Task GetLogradouroAsync(int id);
        Task PutLogradouroAsync(int id);
        Task DeleteLogradouroAsync(int id);
    }
}

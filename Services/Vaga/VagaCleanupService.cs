using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ChronosApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class VagaCleanupService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<VagaCleanupService> _logger;
    private Timer? _timer;

    public VagaCleanupService(IServiceScopeFactory scopeFactory, ILogger<VagaCleanupService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ExecuteCleanup, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    private async void ExecuteCleanup(object? state)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            var vagasVencidas = await context.TB_VAGA
                .Where(v => v.DataVencimento < DateTime.UtcNow)
                .ToListAsync();

            if (vagasVencidas.Any())
            {
                context.TB_VAGA.RemoveRange(vagasVencidas);
                await context.SaveChangesAsync();
                _logger.LogInformation($"Excluídas {vagasVencidas.Count} vagas vencidas.");
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}

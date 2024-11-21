using ChronosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class CursoCleanupService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<CursoCleanupService> _logger;
    private Timer? _timer;

    public CursoCleanupService(IServiceScopeFactory scopeFactory, ILogger<CursoCleanupService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ExecuteCleanup, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        return Task.CompletedTask;
    }

    private async void ExecuteCleanup(object? state)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            var cursosVencidos = await context.TB_CURSO
                .Where(c => c.dataFimCurso < DateTime.UtcNow) 
                .ToListAsync();

            if (cursosVencidos.Any())
            {
                context.TB_CURSO.RemoveRange(cursosVencidos);
                await context.SaveChangesAsync();

                _logger.LogInformation($"Excluídos {cursosVencidos.Count} cursos vencidos.");
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

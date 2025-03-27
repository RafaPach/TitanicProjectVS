using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperPathways.Services
{
    public class CsvWorker : BackgroundService
    {
        private readonly ILogger<CsvWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public CsvWorker(ILogger<CsvWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CSV Worker running at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var csvService = scope.ServiceProvider.GetRequiredService<CsvService>();
                    csvService.RetrieveCsv();
                }

                // Run once on startup, remove if I periodic executions.
                break;
            }
        }
    }
}

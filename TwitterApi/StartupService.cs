using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterApi
{
    public class StartupService : IHostedService
    {
        private readonly ILogger<StartupService> logger;
        private readonly IWorker worker;
        public StartupService(ILogger<StartupService> logger, IWorker worker)
        {
            this.logger = logger;
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.StartStream(cancellationToken);
        }

        // noop
        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Task is stopping");
            return Task.CompletedTask;
        }
    }
}
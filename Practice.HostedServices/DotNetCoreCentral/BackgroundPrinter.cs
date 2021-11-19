using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.HostedServices.DotNetCoreCentral
{
    public class BackgroundPrinter : BackgroundService
    {
        private readonly IWorker worker;

        public BackgroundPrinter(IWorker worker)
        {
            this.worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DoWork(stoppingToken);
        }
    }
}

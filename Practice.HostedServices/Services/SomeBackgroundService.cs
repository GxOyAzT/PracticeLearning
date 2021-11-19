using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.HostedServices.Services
{
    public class SomeBackgroundService : BackgroundService
    {
        private readonly ILogger<SomeBackgroundService> _logger;

        public SomeBackgroundService(ILogger<SomeBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SomeBackgroundService started");

            return Task.CompletedTask;
        }
    }
}

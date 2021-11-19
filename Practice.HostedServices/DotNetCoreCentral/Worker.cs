using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.HostedServices.DotNetCoreCentral
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private int number = 0;
        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation($"------------------------------------------------------------------------");
                Task task1 = Task.Factory.StartNew(() =>
                {
                    Interlocked.Increment(ref number);
                    int secondWaiting = new Random().Next(1, 5);
                    logger.LogInformation($"Waiting for {secondWaiting} seconds");
                    Thread.Sleep(secondWaiting * 1000);
                });
                logger.LogInformation($"Worker Print: {number}");
                Task task2 = Task.Delay(1000 * 2);
                task2.Start();

                Task.WaitAll(new Task[] { task1, task2 });

                logger.LogInformation($"Worker done");
            }
        }
    }
}

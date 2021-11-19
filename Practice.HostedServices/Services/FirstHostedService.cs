using Microsoft.Extensions.Hosting;
using Practice.HostedServices.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.HostedServices.Services
{
    public class FirstHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private Timer _timer;
        private ProductCRUD _productCRUD = new ProductCRUD();

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _productCRUD.Insert(new Models.ProductModel()
            {
                Id = ++executionCount,
                Name = $"Name {executionCount}",
                Price = 2
            });

            Thread.Sleep((new Random()).Next(1000 * 3, 1000 * 8));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

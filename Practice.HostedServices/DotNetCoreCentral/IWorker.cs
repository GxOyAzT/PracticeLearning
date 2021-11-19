using System.Threading;
using System.Threading.Tasks;

namespace Practice.HostedServices.DotNetCoreCentral
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
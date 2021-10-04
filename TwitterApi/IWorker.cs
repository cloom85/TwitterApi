using System.Threading;
using System.Threading.Tasks;

namespace TwitterApi
{
    public interface IWorker
    {
        Task StartStream(CancellationToken cancellationToken);
    }

}
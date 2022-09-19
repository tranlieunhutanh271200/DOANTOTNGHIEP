using System.Threading.Tasks;

namespace Course.gRPC.Services
{
    public interface IHubService
    {
        ValueTask<bool> Refresh();
    }
}
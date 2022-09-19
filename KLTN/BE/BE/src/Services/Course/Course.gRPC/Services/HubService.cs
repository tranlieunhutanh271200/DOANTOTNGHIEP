using System.Net.Http;
using System.Threading.Tasks;

namespace Course.gRPC.Services
{
    public class HubService : IHubService
    {
        private readonly HttpClient _httpClient;
        public HubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<bool> Refresh()
        {
            var result = await _httpClient.GetAsync("/api/message/refresh");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
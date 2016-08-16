using System;
using System.Threading.Tasks;

namespace Infrastructure.Remote.RabbitMQ
{
    public class RmqOverviewServiceProxy
    {
        private readonly IHttpClientProxy _httpClientProxy;

        public RmqOverviewServiceProxy(IHttpClientProxy httpClientProxy)
        {
            if (httpClientProxy == null)
                throw new ArgumentNullException();

            _httpClientProxy = httpClientProxy;
        }

        public async Task<string> GetOverview()
        {
            var response = await _httpClientProxy.GetAsync("overview").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }
    }
}

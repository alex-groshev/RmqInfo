using System;
using System.Threading.Tasks;

namespace Infrastructure.Remote.RabbitMQ
{
    public class RmqNodesServiceProxy
    {
        private readonly IHttpClientProxy _httpClientProxy;

        public RmqNodesServiceProxy(IHttpClientProxy httpClientProxy)
        {
            if (httpClientProxy == null)
                throw new ArgumentNullException();

            _httpClientProxy = httpClientProxy;
        }

        public async Task<string> GetNodes()
        {
            var response = await _httpClientProxy.GetAsync("nodes").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }
    }
}

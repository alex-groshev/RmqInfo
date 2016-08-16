using System;
using System.Threading.Tasks;

namespace Infrastructure.Remote.RabbitMQ
{
    public class RmqClusterNameServiceProxy
    {
        private readonly IHttpClientProxy _httpClientProxy;

        public RmqClusterNameServiceProxy(IHttpClientProxy httpClientProxy)
        {
            if (httpClientProxy == null)
                throw new ArgumentNullException();

            _httpClientProxy = httpClientProxy;
        }

        public async Task<string> GetClusterName()
        {
            var response = await _httpClientProxy.GetAsync("cluster-name").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }
    }
}

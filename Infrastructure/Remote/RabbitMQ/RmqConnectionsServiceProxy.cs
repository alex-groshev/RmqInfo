using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Rmq;
using Newtonsoft.Json;

namespace Infrastructure.Remote.RabbitMQ
{
    public class RmqConnectionsServiceProxy
    {
        private readonly IHttpClientProxy _httpClientProxy;

        public RmqConnectionsServiceProxy(IHttpClientProxy httpClientProxy)
        {
            if (httpClientProxy == null)
                throw new ArgumentNullException();

            _httpClientProxy = httpClientProxy;
        }

        public async Task<List<ConnectionDto>> GetConnectionsAsync()
        {
            var response = await _httpClientProxy.GetAsync("connections").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<ConnectionDto>>(content);
            }
            return new List<ConnectionDto>();
        }
    }
}

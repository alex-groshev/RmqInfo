using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Rmq;
using Newtonsoft.Json;

namespace Infrastructure.Remote.RabbitMQ
{
    public class RmqQueueServiceProxy
    {
        private readonly IHttpClientProxy _httpClientProxy;

        public RmqQueueServiceProxy(IHttpClientProxy httpClientProxy)
        {
            if (httpClientProxy == null)
                throw new ArgumentNullException();

            _httpClientProxy = httpClientProxy;
        }

        public async Task<List<QueueDto>> GetQueuesAsync()
        {
            var response = await _httpClientProxy.GetAsync("queues").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<QueueDto>>(content);
            }
            return new List<QueueDto>();
        }
    }
}

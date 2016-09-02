using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Rmq;
using Newtonsoft.Json;

namespace Infrastructure.Remote.RabbitMQ
{
    public class RmqExchangeServiceProxy
    {
        private readonly IHttpClientProxy _httpClientProxy;

        public RmqExchangeServiceProxy(IHttpClientProxy httpClientProxy)
        {
            if (httpClientProxy == null)
                throw new ArgumentNullException();

            _httpClientProxy = httpClientProxy;
        }

        public async Task<List<ExchangeDto>> GetExchangesAsync()
        {
            var response = await _httpClientProxy.GetAsync("exchanges").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<ExchangeDto>>(content);
            }
            return new List<ExchangeDto>();
        }
    }
}

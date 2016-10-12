using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqExchangeRepository
        : RmqRepository, IRmqExchangeRepository
    {
        public RmqExchangeRepository() { }

        public RmqExchangeRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<List<RmqExchange>> GetExchangesAsync()
        {
            var service = new RmqExchangeServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            var dtos = await service.GetExchangesAsync().ConfigureAwait(false);
            return dtos
                .Select(x => RmqExchange
                    .GetBuilder()
                    .WithName(x.Name)
                    .WithVhost(x.Vhost)
                    .WithType(x.Type)
                    .WithDurable(x.Durable)
                    .WithAutoDelete(x.AutoDelete)
                    .WithInternal(x.Internal)
                    .Build())
                .ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqExchangeRepository : RmqRepository, IRmqExchangeRepository
    {
        public RmqExchangeRepository() { }

        public RmqExchangeRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<List<RmqExchange>> GetExchangesAsync()
        {
            var service = new RmqExchangeServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            var exchangeDtos = await service.GetExchangesAsync().ConfigureAwait(false);
            return exchangeDtos
                .Select(x => new RmqExchange(x.Name, x.Vhost, x.Type, x.Durable, x.AutoDelete, x.Internal))
                .ToList();
        }
    }
}

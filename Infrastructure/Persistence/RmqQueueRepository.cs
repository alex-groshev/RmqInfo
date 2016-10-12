using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqQueueRepository
        : RmqRepository, IRmqQueueRepository
    {
        public RmqQueueRepository() { }

        public RmqQueueRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<List<RmqQueue>> GetQueuesAsync()
        {
            var service = new RmqQueueServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            var dtos = await service.GetQueuesAsync().ConfigureAwait(false);
            return dtos
                .Select(x => RmqQueue
                    .GetBuilder()
                    .WithName(x.Name)
                    .WithVhost(x.Vhost)
                    .WithDurable(x.Durable)
                    .WithAutoDelete(x.AutoDelete)
                    .WithExclusive(x.Exclusive)
                    .Build())
                .ToList();
        }
    }
}

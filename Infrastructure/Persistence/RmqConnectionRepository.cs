using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqConnectionRepository : RmqRepository, IRmqConnectionRepository
    {
        public RmqConnectionRepository() { }

        public RmqConnectionRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<List<RmqConnection>> GetConnectionsAsync()
        {
            var service = new RmqConnectionsServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            var dtos = await service.GetConnectionsAsync().ConfigureAwait(false);
            return dtos.Select(c =>
                new RmqConnection(c.User, c.Host, c.Port, c.PeerHost, c.PeerPort,
                        new RmqConnectionStatus(c.ConnectedAt.UnixTimeStampToDateTime(), c.State))).ToList();
        }
    }
}

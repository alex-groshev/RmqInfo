using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqNodesRepository : RmqRepository, IRmqNodesRepository
    {
        public RmqNodesRepository() { }

        public RmqNodesRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<string> GetNodesAsync()
        {
            var rmq = new RmqNodesServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            return await rmq.GetNodes().ConfigureAwait(false);
        }
    }
}

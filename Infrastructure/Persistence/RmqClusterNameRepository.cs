using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqClusterNameRepository : RmqRepository, IRmqClusterNameRepository
    {
        public RmqClusterNameRepository() { }

        public RmqClusterNameRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<string> GetClusterNameAsync()
        {
            var rmq = new RmqClusterNameServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            return await rmq.GetClusterName();
        }
    }
}

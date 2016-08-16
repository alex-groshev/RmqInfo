using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Remote;
using Infrastructure.Remote.RabbitMQ;

namespace Infrastructure.Persistence
{
    public class RmqOverviewRepository : RmqRepository, IRmqOverviewRepository
    {
        public RmqOverviewRepository() { }

        public RmqOverviewRepository(string baseAddress, string login, string password)
            : base(baseAddress, login, password) { }

        public async Task<string> GetOverviewAsync()
        {
            var rmq = new RmqOverviewServiceProxy(new HttpClientProxy(BaseAddress, Login, Password));
            return await rmq.GetOverview();
        }
    }
}

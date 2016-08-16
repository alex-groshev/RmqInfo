using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IRmqConnectionRepository
    {
        Task<List<RmqConnection>> GetConnectionsAsync();
    }
}

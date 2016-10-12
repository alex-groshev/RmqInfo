using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IRmqQueueRepository
    {
        Task<List<RmqQueue>> GetQueuesAsync();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IRmqExchangeRepository
    {
        Task<List<RmqExchange>> GetExchangesAsync();
    }
}

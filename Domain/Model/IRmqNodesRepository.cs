using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IRmqNodesRepository
    {
        Task<string> GetNodesAsync();
    }
}

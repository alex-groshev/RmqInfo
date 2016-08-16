using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IRmqClusterNameRepository
    {
        Task<string> GetClusterNameAsync();
    }
}

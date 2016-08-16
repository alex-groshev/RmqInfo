using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IRmqOverviewRepository
    {
        Task<string> GetOverviewAsync();
    }
}

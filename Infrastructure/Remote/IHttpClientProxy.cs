using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Remote
{
    public interface IHttpClientProxy
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}

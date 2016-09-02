using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Remote
{
    public class HttpClientProxy : IHttpClientProxy
    {
        private readonly string _baseAddress;
        private readonly string _credentials;

        public HttpClientProxy(string baseAddress)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException(nameof(baseAddress));

            _baseAddress = baseAddress;
        }

        public HttpClientProxy(string baseAddress, string credentials)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException(nameof(baseAddress));

            if (string.IsNullOrEmpty(credentials))
                throw new ArgumentException(nameof(credentials));

            _baseAddress = baseAddress;
            _credentials = credentials;
        }

        public HttpClientProxy(string baseAddress, string username, string password)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException(nameof(baseAddress));

            if (string.IsNullOrEmpty(username))
                throw new ArgumentException(nameof(username));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            _baseAddress = baseAddress;
            _credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(_credentials))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);

                return await client.GetAsync(url).ConfigureAwait(false);
            }
        }
    }
}

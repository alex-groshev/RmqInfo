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
                throw new ArgumentException("baseAddress");

            _baseAddress = baseAddress;
        }

        public HttpClientProxy(string baseAddress, string credentials)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException("baseAddress");

            if (string.IsNullOrEmpty(credentials))
                throw new ArgumentException("credentials");

            _baseAddress = baseAddress;
            _credentials = credentials;
        }

        public HttpClientProxy(string baseAddress, string username, string password)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException("baseAddress");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password");

            _baseAddress = baseAddress;
            _credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password)));
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

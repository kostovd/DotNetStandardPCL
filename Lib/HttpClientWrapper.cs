using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpMessageHandler httpMessageHandler = null)
        {
            _httpClient = (httpMessageHandler != null ? new HttpClient(httpMessageHandler) : new HttpClient());

            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetUserAsync()
        {
            string result = string.Empty;

            var response = await _httpClient.GetAsync("users/1");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        public async Task<dynamic> GetUserAsyncJson()
        {
            dynamic result = null;

            var response = await _httpClient.GetAsync("users/1");
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    result = ReadJson<dynamic>(stream);
                }
            }

            return result;
        }

        private T ReadJson<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                using (var jr = new JsonTextReader(reader))
                {
                    var jsonSerializer = new JsonSerializer();
                    return jsonSerializer.Deserialize<T>(jr);
                }
            }
        }
    }
}

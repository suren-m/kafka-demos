using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class OrdersService
    {
        public HttpClient Client { get; }

        public OrdersService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://httpbin.org/");
            Client = client;
        }

        public async Task<string> GetSomeText(string base64Str)
        {
            return await Client.GetStringAsync($"base64/{base64Str}");
        }
    }
}
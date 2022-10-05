using Application.Connectors;
using Application.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PastelProvider.Integration.Resource;
using System.Net;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace PastelProvider.Integration
{
    public class PastelConnector : IPastelConnector
    {
        private readonly HttpClient httpClient;

        public PastelConnector(HttpClient httpClient, string baseUrl)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<IList<Pastel>> FindAll()
        {
            return (await DoGetAsync<PastelResource>("pastel"))
                .Select(pr => new Pastel(pr.Name ?? "") { Ingredients = pr.Ingredients, IsSweet = pr.IsSweet })
                .ToList();
        }

        private async Task<T[]> DoGetAsync<T>(string path)
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
            try
            {

                var response = await httpClient.GetAsync(path);
                var contentString = await response.Content.ReadAsStringAsync();
                return Deserialize<T>(contentString);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static T[] Deserialize<T>(string contentString)
        {
            var obj = JsonConvert.DeserializeObject(contentString);
            var jsonSerializer = new JsonSerializer();
            if (obj is JArray array)
            {
                return array.Children()
                    .Select(c => c.ToObject<T>(jsonSerializer))
                    .ToArray();
            }
            else if (obj is JObject jsonObj)
            {
                return new[] { jsonObj.ToObject<T>(jsonSerializer) };
            }
            return null;
        }
    }
}
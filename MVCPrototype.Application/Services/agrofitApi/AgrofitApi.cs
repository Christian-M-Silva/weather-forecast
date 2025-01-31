using MVCPrototype.Domain.Entities;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MVCPrototype.Application.Services.agrofitApi
{
    public class AgrofitApi(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<ProdutosFormuladosResponse>> GetAgroDataAsync(string accessToken)
        {
            try
            {
                string url = $"https://api.cnptia.embrapa.br/agrofit/v1/produtos-formulados?page=1";

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                };

                List<ProdutosFormuladosResponse> result = JsonConvert.DeserializeObject<List<ProdutosFormuladosResponse>>(jsonString, settings);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
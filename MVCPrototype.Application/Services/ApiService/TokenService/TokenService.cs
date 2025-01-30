using Microsoft.Extensions.Configuration;
using MVCPrototype.Domain.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class TokenService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;


    public TokenService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        string consumerKey = _configuration["AgroApi:ConsumerKey"];
        string consumerSecret = _configuration["AgroApi:ConsumerSecret"];
        string url = "https://api.cnptia.embrapa.br/token";
        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{consumerKey}:{consumerSecret}"));

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<TokenResponse>(jsonResponse, options);

        return result?.AccessToken ?? throw new Exception("Token não obtido");
    }
}

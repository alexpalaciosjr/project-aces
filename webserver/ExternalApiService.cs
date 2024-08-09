using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using webserver.Models;
using Microsoft.AspNetCore.WebUtilities;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    private readonly string BaseUrl = "localhost:5000";

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetFieldsAsync(Dictionary<string, string> queryParams)
    {
        var url = QueryHelpers.AddQueryString($"{BaseUrl}/fields", queryParams);
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PostFieldsAsync(object data)
    {
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{BaseUrl}/fields", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
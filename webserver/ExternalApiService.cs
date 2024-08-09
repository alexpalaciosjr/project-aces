using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static webserver.Constants;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    private readonly string BaseUrl = "localhost:5000"

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetFieldsAsync(Dictionary<string, string> queryParams)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        foreach (var param in queryParams)
        {
            query[param.Key] = param.Value;
        }
        var queryString = query.ToString();
        var response = await _httpClient.GetAsync($"{BaseUrl}/fields?{queryString}");
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
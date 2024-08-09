var builder = WebApplication.CreateBuilder(args);

// Register the ExternalApiService with HttpClient
builder.Services.AddHttpClient<ExternalApiService>();

var app = builder.Build();

app.MapGet("/fields", async (HttpContext context, ExternalApiService apiService) =>
{
    var queryParams = context.Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
    var data = await apiService.GetExternalDataAsync(queryParams);
    return data;
});

public async Task<string> PostExternalDataAsync(Field field)
    {
        var json = JsonConvert.SerializeObject(field);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{BaseUrl}/fields", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

app.Run();
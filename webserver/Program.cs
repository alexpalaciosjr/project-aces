var builder = WebApplication.CreateBuilder(args);

// Register the ExternalApiService with HttpClient
builder.Services.AddHttpClient<ExternalApiService>();

var app = builder.Build();

app.MapGet("/", async (ExternalApiService apiService) =>
{
    var data = await apiService.GetExternalDataAsync();
    return data;
});

app.Run();
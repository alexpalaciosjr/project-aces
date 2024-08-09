using webserver.Models;

var builder = WebApplication.CreateBuilder(args);

// Register the ExternalApiService with HttpClient
builder.Services.AddHttpClient<ExternalApiService>();

var app = builder.Build();

app.MapGet("/fields", async (HttpContext context, ExternalApiService apiService) =>
{
    var queryParams = context.Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
    var data = await apiService.GetFieldsAsync(queryParams);
    return data;
});

app.MapPost("/fields", async (Field field, ExternalApiService apiService) =>
{
    var response = await apiService.PostFieldsAsync(field);
    return response;
});

app.Run();
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/baganmap", () =>
{
    string folderPath = "Data/BaganMap.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BaganMapResponseModel>(jsonStr)!;
    return Results.Ok(result.Tbl_BaganMapInfoData);
})
.WithName("GetBaganMapInfoData")
.WithOpenApi();

app.MapGet("/baganmap/{id}", (int id) =>
{
    string folderPath = "Data/BaganMap.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BaganMapResponseModel>(jsonStr)!;

    var item = result.Tbl_BaganMapInfoData.FirstOrDefault(x => x.Id.ToString() == id.ToString());

    if(item is null)
    {
        return Results.BadRequest("No data found.");
    }
    return Results.Ok(item);
})
.WithName("GetBaganMapInfo")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class BaganMapResponseModel
{
    public BaganmapinfodataModel[] Tbl_BaganMapInfoData { get; set; }
    public BaganmapinfodetaildataModel[] Tbl_BaganMapInfoDetailData { get; set; }
    public TravelroutelistdataModel[] Tbl_TravelRouteListData { get; set; }
}

public class BaganmapinfodataModel
{
    public string Id { get; set; }
    public string PagodaMmName { get; set; }
    public string PagodaEngName { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}

public class BaganmapinfodetaildataModel
{
    public string Id { get; set; }
    public string Description { get; set; }
}

public class TravelroutelistdataModel
{
    public string TravelRouteId { get; set; }
    public string TravelRouteName { get; set; }
    public string TravelRouteDescription { get; set; }
    public string[] PagodaList { get; set; }
}


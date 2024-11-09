using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using THTZDotNetCore.Database.Models;
using THTZDotNetCore.MinimalApi.Endpoints.Blog;

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

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//app.MapGet("/blogs", () =>
//{
//    AppDbContext db = new AppDbContext();
//    var model = db.TblBlogs.AsNoTracking().ToList();
//    return Results.Ok(model);
//})
//.WithName("GetBlogs")
//.WithOpenApi();

//app.MapGet("/blogs/{id}", (int id) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

//    if (item is null)
//    {
//        return Results.BadRequest("No data found.");
//    }
//    return Results.Ok(item);
//})
//.WithName("GetBlog")
//.WithOpenApi();

//app.MapPost("/blogs", (TblBlog blog) =>
//{
//    AppDbContext db = new AppDbContext();
//    db.TblBlogs.Add(blog);
//    db.SaveChanges();
//    return Results.Ok(blog);
//})
//.WithName("CreateBlog")
//.WithOpenApi();

//app.MapPut("/blogs", (int id, TblBlog blog) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

//    if (item is null)
//    {
//        return Results.BadRequest("No data found.");
//    }

//    item.BlogTitle = blog.BlogTitle;
//    item.BlogAuthor = blog.BlogAuthor;
//    item.BlogContent = blog.BlogContent;

//    db.Entry(item).State = EntityState.Modified;

//    db.SaveChanges();
//    return Results.Ok(blog);
//})
//.WithName("UpdateBlogs")
//.WithOpenApi();

//app.MapPatch("/blogs", (int id, TblBlog blog) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

//    if (item is null)
//    {
//        return Results.BadRequest("No data found.");
//    }

//    if (!string.IsNullOrEmpty(blog.BlogTitle))
//    {
//        item.BlogTitle = blog.BlogTitle;
//    }
//    if (!string.IsNullOrEmpty(blog.BlogAuthor))
//    {
//        item.BlogAuthor = blog.BlogAuthor;
//    }
//    if (!string.IsNullOrEmpty(blog.BlogContent))
//    {
//        item.BlogContent = blog.BlogContent;
//    }

//    db.Entry(item).State = EntityState.Modified;

//    db.SaveChanges();
//    return Results.Ok(blog);
//})
//.WithName("UpdateBlog")
//.WithOpenApi();

//app.MapDelete("/blogs/{id}", (int id) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

//    if (item is null)
//    {
//        return Results.BadRequest("No data found.");
//    }

//    db.Entry(item).State = EntityState.Deleted;

//    db.SaveChanges();
//    return Results.Ok();
//})
//.WithName("DeleteBlog")
//.WithOpenApi();

//BlogEndpoint.Test(9);
//9.Test();

app.UseBlogEndpoint();

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}

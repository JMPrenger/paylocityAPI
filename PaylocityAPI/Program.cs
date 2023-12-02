using PaylocityAPI;
using System.Diagnostics;

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

app.MapPost("/AddObject", async (PaylocityDto dto) =>
{
    try
    {
        var objectList = await PaylocityFileManipulator.ReadFile();
        objectList.Add(dto);

        await PaylocityFileManipulator.WriteObjectToFile(objectList);
        return Results.Ok();

    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Results.StatusCode(500);
    }

}).WithOpenApi();

app.MapGet("/GetAllObjects", async () =>
{
    try
    {
        var objectList = await PaylocityFileManipulator.ReadFile();
        return Results.Ok(objectList);
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Results.StatusCode(500);
    }
})
.WithOpenApi();

app.Run();



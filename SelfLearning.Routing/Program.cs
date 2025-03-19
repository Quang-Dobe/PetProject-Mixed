var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    Console.WriteLine($"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

// app.Use(async (context, next) =>
// {
//     var currentEndpoint = context.GetEndpoint();

//     if (currentEndpoint is null)
//     {
//         await next(context);
//         return;
//     }

//     Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

//     if (currentEndpoint is RouteEndpoint routeEndpoint)
//     {
//         Console.WriteLine($"  - Route Pattern: {routeEndpoint.RoutePattern}");
//     }

//     foreach (var endpointMetadata in currentEndpoint.Metadata)
//     {
//         Console.WriteLine($"  - Metadata: {endpointMetadata}");
//     }

//     await next(context);
// });

app.MapControllers();

app.Run();

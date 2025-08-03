using Microsoft.EntityFrameworkCore;
using RegistrationApi.Context;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Log current environment
Console.WriteLine("Environment: " + builder.Environment.EnvironmentName);

// Register DB context based on environment
builder.Services.AddDbContext<Contexts>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Environment-based error handling
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Optional: Log exceptions in production
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/plain";

            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            await context.Response.WriteAsync("An error occurred: " + exceptionHandlerPathFeature?.Error?.Message);
        });
    });
}
//aded prod
// Swagger always enabled
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();

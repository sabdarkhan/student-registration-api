using Microsoft.EntityFrameworkCore;
using RegistrationApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Registers correct connection string based on environment
builder.Services.AddDbContext<Contexts>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger always (so it works in Production too)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

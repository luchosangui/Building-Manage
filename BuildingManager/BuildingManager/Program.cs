using Microsoft.EntityFrameworkCore;
using Data;
using ServicesFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<BuildingManagerContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("BuildingManagerDB"),
        providerOptions => providerOptions.EnableRetryOnFailure())
    );

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var servicesFactory = new ServicesFactory.ServicesFactory();
servicesFactory.ConfigureServices(builder.Services);

builder.Services.AddCors(options =>
              options.AddPolicy("AllowAll", policy =>
                  policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod())
              );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

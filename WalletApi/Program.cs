using Microsoft.EntityFrameworkCore;
using WalletApi.Data;
using WalletApi.Mappings;
using WalletApi.Repositories;
using WalletApi.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//using di to inject the dbContext into the application
builder.Services.AddDbContext<WalletDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("WalletConnectionString")));

//using di to inject the repository interface and the implementation into the context
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

//using di to inject the AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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

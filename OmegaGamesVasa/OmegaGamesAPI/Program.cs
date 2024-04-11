using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectStringLocal = builder.Configuration.GetConnectionString("OmegaGamesVasa");
var connectionStringAzure = builder.Configuration.GetConnectionString("OmegaGamesVasaAzure");

builder.Services.AddDbContext<OmegaGamesDbContext>(options => options.UseSqlServer(connectionStringAzure));

builder.Services.AddScoped<IProductService<Product>, ProductRepository>();

builder.Services.AddFastEndpoints();
var app = builder.Build();
//TODO: Repositories

app.UseFastEndpoints();

app.Run();

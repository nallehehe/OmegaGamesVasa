using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using OmegaGamesAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectStringLocal = builder.Configuration.GetConnectionString("OmegaGamesVasa");
var connectionStringAzure = builder.Configuration.GetConnectionString("OmegaGamesVasaAzure");

builder.Services.AddDbContext<OmegaGamesDbContext>(options => options.UseSqlServer(connectionStringAzure));

builder.Services.AddScoped<IProductService<Product>, ProductRepository>();

var app = builder.Build();
//TODO: Repositories

app.MapProductsEndpoints();

app.Run();

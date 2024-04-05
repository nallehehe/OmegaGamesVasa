using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using OmegaGamesAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("OmegaGamesVasa");

builder.Services.AddDbContext<OmegaGamesDbContext>(options => options.UseSqlServer(connectString));

builder.Services.AddScoped<IProductService<Product>, ProductRepository>();

var app = builder.Build();
//TODO: Repositories

app.MapProductsEndpoints();

app.Run();

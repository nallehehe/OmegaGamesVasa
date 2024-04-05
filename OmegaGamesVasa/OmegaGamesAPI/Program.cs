using DataAccess;
using Microsoft.EntityFrameworkCore;
using OmegaGamesAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("OmegaGamesVasa");
builder.Services.AddDbContext<OmegaGamesDbContext>(options => options.UseSqlServer(connectString));


var app = builder.Build();
//TODO: Repositories

app.MapProductsEndpoints();

app.Run();

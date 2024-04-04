using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//var connectionString = builder.Configuration.GetConnectionString("OmegaGamesVasa");
//builder.Services.AddDbContext<OmegaGamesVasaDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});

app.Run();

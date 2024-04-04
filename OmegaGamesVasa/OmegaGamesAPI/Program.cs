using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("OmegaGamesVasa");
builder.Services.AddDbContext<OmegaGamesDbContext>(options => options.UseSqlServer(connectString));


var app = builder.Build();
//TODO: Repositories

app.Run();

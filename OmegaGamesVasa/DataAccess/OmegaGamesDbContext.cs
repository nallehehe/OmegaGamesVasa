using DataAccess.Entities;
using DataAccess.Entities.Codes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OmegaGamesDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductCode> ProductCodes { get; set; }

    public DbSet<Event> Events { get; set; }

    public OmegaGamesDbContext(DbContextOptions options) : base(options)
    {

    }
}
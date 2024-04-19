using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OmegaGamesDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public OmegaGamesDbContext(DbContextOptions options) : base(options)
    {

    }

}
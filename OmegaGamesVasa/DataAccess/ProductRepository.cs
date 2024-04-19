using Common.Interface;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ProductRepository(OmegaGamesDbContext _context) : IProductService<Product>
{

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddProductAsync(Product product)
    {
       await _context.Products.AddAsync(product);
       await _context.SaveChangesAsync();
    }

}
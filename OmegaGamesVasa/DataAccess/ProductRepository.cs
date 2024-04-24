using Common.Interface;
using DataAccess.Entities;
using DataAccess.Entities.Codes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ProductRepository(OmegaGamesDbContext _context) : IProductService<Product>
{

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetAllGames()
    {
        var games = await _context.Products.Where(g => g.Category == "Games").ToListAsync();
        return games;
    }

    public async Task AddProductAsync(Product product)
    {
       await _context.Products.AddAsync(product);
       await _context.SaveChangesAsync();
    }

    public async Task<string> GetAndUseProductCode(int productId)
    {

        var product = await _context.Products.Include(p => p.Codes).FirstOrDefaultAsync(p => p.Id == productId);

        var foundCode = product.Codes.FirstOrDefault(c => c.IsUsed == false);

        if (foundCode == null)
        {
            return null;
        }

        return foundCode.Key;
    }

}
using Common.Interface;
using DataAccess.Entities;
using DataAccess.Entities.Codes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ProductCodeRepository(OmegaGamesDbContext _context) : IProductCodeService<ProductCode>
{
   

    public async Task UpdateProductCodeIsUsedAsync(string key)
    {
        var selectedCode = _context.ProductCodes.FirstOrDefault(c => c.Key == key);

        if (selectedCode == null)
        {
            return;
        }

        selectedCode.IsUsed = true;
        await _context.SaveChangesAsync();
    }

    public async Task AddProductCodeAsync(ProductCode productCode)
    {
        await _context.ProductCodes.AddAsync(productCode);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductCode>> GetAllProductCodeAsync()
    {
        return await _context.ProductCodes.ToListAsync();
    }
}
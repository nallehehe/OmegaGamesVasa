namespace Common.Interface;

public interface IProductCodeService<T> where T : class
{
    Task AddProductCodeAsync(T productCode);
    Task<IEnumerable<T>> GetAllProductCodeAsync();
    Task UpdateProductCodeIsUsedAsync(string key);
}
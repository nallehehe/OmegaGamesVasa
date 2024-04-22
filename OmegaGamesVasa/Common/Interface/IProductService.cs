namespace Common.Interface;

public interface IProductService<T> where T : class
{
    Task<IEnumerable<T>> GetAllProducts();

    Task AddProductAsync(T product);

    Task<string> GetAndUseProductCode(int productId);
}
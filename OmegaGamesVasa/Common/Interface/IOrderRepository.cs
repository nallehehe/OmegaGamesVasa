using Common.DTO;

namespace Common.Interface;

public interface IOrderRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();

    Task<T> AddOrderAsync(T product);
    Task<T> UpdateOrderAsync(T product);
}
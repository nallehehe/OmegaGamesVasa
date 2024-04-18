using Common.DTO;
using Common.Interface;

namespace OmegaGamesAPI.Services;

public class OrderService : IOrderRepository<OrderDTO>
{

    private readonly HttpClient _httpClient;

    public OrderService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("OmegaGamesAPI");
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        var response = await _httpClient.GetAsync("orders");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<OrderDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
        return result ?? Enumerable.Empty<OrderDTO>();
    }

    public async Task<bool> AddOrderAsync(OrderDTO order)
    {
        var response = await _httpClient.PostAsJsonAsync("orders", order);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
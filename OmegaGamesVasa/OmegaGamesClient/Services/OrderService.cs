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
        var response = await _httpClient.PostAsJsonAsync("https://prod-252.westeurope.logic.azure.com:443/workflows/1d02d2cc74c944248d19897ea4d05f3a/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=1.0&sig=qGcXA-u9OyVqIlKcGtLW3VFIAhJCmdgP-CYZTJZsDcs", order);

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
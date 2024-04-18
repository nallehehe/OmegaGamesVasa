using Common.DTO;
using Common.Interface;

namespace OmegaGamesAPI.Services;

public class OrderService : IOrderRepository<OrderDTO>
{

    private readonly HttpClient _httpClient;
    private readonly HttpClient _emailHttpClient;
    private readonly IConfiguration _configuration;

    public OrderService(IHttpClientFactory factory, IConfiguration configuration)
    {
        _httpClient = factory.CreateClient("OmegaGamesAPI");
        _emailHttpClient = factory.CreateClient("EmailLogicAppClient");
        _configuration = configuration;
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

    public async Task<OrderDTO> AddOrderAsync(OrderDTO order)
    {
        var response = await _httpClient.PostAsJsonAsync("orders", order);
        var addedOrder = response.Content.ReadFromJsonAsync<OrderDTO>().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        else
        {
            var emailDisabled = _configuration.GetValue<bool>("DisableLogicApp");
            if (!emailDisabled)
            {
                var content = JsonContent.Create(addedOrder);
                await content.LoadIntoBufferAsync();
                var response2 = await _emailHttpClient.PostAsync("", content);
            }
            return addedOrder;
        }
    }
}
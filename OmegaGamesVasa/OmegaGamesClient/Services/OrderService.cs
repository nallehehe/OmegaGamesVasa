using Common.DTO;
using Common.Interface;

namespace OmegaGamesAPI.Services;

public class OrderService : IOrderRepository<OrderDTO>
{

    private readonly HttpClient _httpClient;
    private readonly HttpClient _emailHttpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public OrderService(IHttpClientFactory factory, IConfiguration configuration, ILogger<OrderService> logger)
    {
        _httpClient = factory.CreateClient("OmegaGamesAPI");
        _emailHttpClient = factory.CreateClient("EmailLogicAppClient");
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        try
        {
            var response = await _httpClient.GetAsync("orders");

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<OrderDTO>();
            }
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
            return result ?? Enumerable.Empty<OrderDTO>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Enumerable.Empty<OrderDTO>();
        }

    }

    public async Task<OrderDTO> ConfirmOrderAsync(OrderDTO order)
    {
        // TODO: Mark order as confirmed in mongodb
        order.OrderStatus = "ORDER_CONFIRMED";
        var productsWithCodes = await GetCodesFromCustomerCart(order.CustomerCart);
        order.CustomerCart = productsWithCodes;
        var updatedOrder = await UpdateOrderAsync(order);

        var emailDisabled = _configuration.GetValue<bool>("DisableLogicApp");
        var customerEmail = order.CustomerEmail;
        if (!emailDisabled && customerEmail != "test@example.com")
        {
            var content = JsonContent.Create(order);
            await content.LoadIntoBufferAsync();
            var response2 = await _emailHttpClient.PostAsync("", content);
        }

        return order;
    }

    public async Task<OrderDTO> AddOrderAsync(OrderDTO order)
    {

        var response = await _httpClient.PostAsJsonAsync("orders", order);

        var addedOrder = await response.Content.ReadFromJsonAsync<OrderDTO>();

        if (!response.IsSuccessStatusCode || addedOrder == null)
        {
            return null;
        }

        return addedOrder;
    }

    public async Task<OrderDTO> UpdateOrderAsync(OrderDTO order)
    {
        var updatedOrder = await _httpClient.PutAsJsonAsync("orders", order);
        if (updatedOrder.IsSuccessStatusCode)
        {
            return order;
        }

        return null;
    }

    private async Task GetCodesFromOrder(OrderDTO orderDto)
    {
        foreach (var product in orderDto.CustomerCart)
        {
            product.ProductKey = await GetProductCode(product);
        }
    }

    private async Task<List<ProductInCartDTO>> GetCodesFromCustomerCart(List<ProductInCartDTO> products)
    {
        foreach (var product in products)
        {
            product.ProductKey = await GetProductCode(product);
        }

        return products;
    }


    private async Task<string> GetProductCode(ProductInCartDTO productDto)
    {
        var response = await _httpClient.GetAsync($"products/code/{productDto.Id}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadAsStringAsync();
        char[] charsToTrim = { '\\', '"' };
        result = result.Trim(charsToTrim);

        return result;
    }

    public async Task<OrderDTO> GetOrderByExternalRefAsync(string externalRef)
    {
        var orders = await GetAllOrders();
        var foundOrder = orders.FirstOrDefault(o => o.ExternalRef == externalRef);
        return foundOrder;
    }

}
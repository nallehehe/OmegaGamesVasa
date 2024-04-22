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
		} catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Enumerable.Empty<OrderDTO>();
		}
        
    }

    public async Task<OrderDTO> AddOrderAsync(OrderDTO order)
    {

        
        var response = await _httpClient.PostAsJsonAsync("orders", order);

        
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        else
        {
            var addedOrder = response.Content.ReadFromJsonAsync<OrderDTO>().Result; 
            var productsAndProductCodes = await GetCodesFromOrder(order);
            addedOrder.ProductCodes = productsAndProductCodes;
            var emailDisabled = _configuration.GetValue<bool>("DisableLogicApp");
            var customerEmail = order.CustomerEmail;
            if (!emailDisabled && customerEmail != "test@example.com")
            {
                var content = JsonContent.Create(addedOrder);
                await content.LoadIntoBufferAsync();
                var response2 = await _emailHttpClient.PostAsync("", content);
            }
            return addedOrder;
        }
    }

    private async Task<Dictionary<int, List<string>>> GetCodesFromOrder(OrderDTO orderDto)
    {
        var keyDict = new Dictionary<int, List<string>>();

        foreach (var product in orderDto.CustomerCart)
        {
            if (!keyDict.ContainsKey(product.Id))
            {
                keyDict.Add(product.Id, new List<string>());
            }

            var productCode = await GetProductCode(product);
            keyDict[product.Id].Add(productCode);
        }
        return keyDict;
    }


    private async Task<string> GetProductCode(ProductDTO productDto)
    {
        var response = await _httpClient.GetAsync($"products/code/{productDto.Id}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadAsStringAsync();
        char[] charsToTrim = {'\\', '"'};
        result = result.Trim(charsToTrim);

        return result;
    }

}
using Common.DTO;
using Common.Interface;

namespace OmegaGamesAPI.Services;

public class ProductService : IProductService<ProductDTO>
{

    private readonly HttpClient _httpClient;

    public ProductService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("OmegaGamesAPI");
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var response = await _httpClient.GetAsync("products");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<ProductDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
        return result ?? Enumerable.Empty<ProductDTO>();
    }   

    public async Task AddProductAsync(ProductDTO product)
    {
        var response = await _httpClient.PostAsJsonAsync("products", product);

        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }

    public Task<string> GetAndUseProductCode(int productId)
    {
        throw new NotImplementedException();
    }
}
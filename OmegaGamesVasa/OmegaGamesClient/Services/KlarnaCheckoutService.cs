using Common.DTO;
using Common.DTO.Klarna;
using Common.Interface;
using OmegaGamesAPI.Services;
namespace OmegaGamesClient.Services
{
    public class KlarnaCheckoutService : ICheckoutService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public KlarnaCheckoutService(IHttpClientFactory factory, IConfiguration configuration, ILogger<KlarnaCheckoutService> logger) {
            _configuration = configuration;
            _logger = logger;
            _httpClient = factory.CreateClient("KlarnaPlayground");
        }

        public async Task<string> CreateOrder()
        {
            var checkoutDTO = new KlarnaCheckoutDTO
            {
                purchase_country = "SE",
                purchase_currency = "SEK",
                locale = "sv",
                order_amount = 50000,
                order_tax_amount = 4545,
                order_lines = new()
                {
                    new KlarnaOrderProductDTO {
                        type = "physical",
                        reference = "1",
                        name = "White Cotton T-Shirt",
                        quantity = 5,
                        quantity_unit = "pcs",
                        unit_price = 10000,
                        tax_rate = 1000,
                        total_amount = 50000,
                        total_discount_amount = 0,
                        total_tax_amount = 4545
                    }
                },
                merchant_urls = new KlarnaMerchantUrlsDTO
                {
                    terms = "https://www.example.com/terms.html",
                    checkout = "https://www.example.com/checkout.html",
                    confirmation = "https://www.example.com/confirmation.html",
                    push = "https://www.example.com/api/push"
                }
            };

            var checkoutDTOContent = JsonContent.Create(checkoutDTO);
            Console.WriteLine(checkoutDTOContent.ToString());

            var response = await _httpClient.PostAsJsonAsync("/checkout/v3/orders", checkoutDTO);
            var result = await response.Content.ReadAsStringAsync();
            var responseDTO = await response.Content.ReadFromJsonAsync<KlarnaResponseDTO>();
            var htmlSnippet = responseDTO.html_snippet;

            return htmlSnippet;

        }

        public async Task<KlarnaOrderDTO> GetOrder(string order_id)
        {
            KlarnaOrderDTO order = new KlarnaOrderDTO();
            var response = await _httpClient.GetAsync($"/checkout/v3/orders/{order_id}");
            var result = await response.Content.ReadFromJsonAsync<KlarnaOrderDTO>();

            return result;
        }
    }
}

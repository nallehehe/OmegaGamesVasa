using Common.DTO;
using Common.DTO.Klarna;
using Common.Interface;
using Microsoft.AspNetCore.Components;
using OmegaGamesAPI.Services;
namespace OmegaGamesClient.Services
{
    public class KlarnaCheckoutService : ICheckoutService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public KlarnaCheckoutService(IHttpClientFactory factory, IConfiguration configuration, ILogger<KlarnaCheckoutService> logger, NavigationManager navigationManager) {
            _configuration = configuration;
            _logger = logger;
            _httpClient = factory.CreateClient("KlarnaPlayground");
            _navigationManager = navigationManager;
        }

        public int GetTaxAmount(int totalAmount, int taxRate)
        {
            double realTaxRate = (double)taxRate / (double)100;
            double changeFactor = 100.0 / (100.0 + realTaxRate);
            return Convert.ToInt32(totalAmount - (totalAmount * changeFactor));
        }

        public async Task<KlarnaResponseDTO> CreateOrder(OrderDTO order)
        {
            var baseUrl = _navigationManager.BaseUri;
            var apiUrl = new Uri(_configuration["OmegaGamesAPIBaseAdress"]);
            var orderAmount = order.CustomerCart.Sum(p => p.Price);
            var klarnaProducts = new List<KlarnaOrderProductDTO>();
            var taxRate = 2500; // TODO: Change to variable from product category when applicable
            foreach (var p in order.CustomerCart.DistinctBy(p => p.Id))
            {
                var totalAmount = order.CustomerCart.Count(c => c.Id == p.Id) * Convert.ToInt32(p.Price * 100);
                var totalTaxAmount = GetTaxAmount(totalAmount, taxRate);
                klarnaProducts.Add(new KlarnaOrderProductDTO {
                    type = "digital", // TODO: Change to variable from product category when applicable
                    reference = p.Id.ToString(),
                    name = p.ProductName,
                    quantity = order.CustomerCart.Count(c => c.Id == p.Id),
                    quantity_unit = "st",
                    unit_price = Convert.ToInt32(p.Price * 100),
                    tax_rate = taxRate,
                    total_amount = totalAmount,
                    total_discount_amount = 0,
                    total_tax_amount = totalTaxAmount,
                    image_url = p.Image
                });
            }

            var customerAddress = new KlarnaAddressDTO
            {
                given_name = order.CustomerFirstName,
                family_name = order.CustomerLastName,
                email = order.CustomerEmail,
                phone = order.CustomerPhone
            };

            var totalOrderAmount = Convert.ToInt32(order.TotalPrice * 100);
            var checkoutDTO = new KlarnaCheckoutDTO
            {
                purchase_country = "SE",
                purchase_currency = "SEK",
                locale = "sv",
                order_amount = totalOrderAmount,
                order_tax_amount = GetTaxAmount(totalOrderAmount, taxRate),
                order_lines = klarnaProducts,
                merchant_urls = new KlarnaMerchantUrlsDTO
                {
                    terms = $"{baseUrl}OrderTerms",
                    checkout = $"{baseUrl}Checkout?order_id={{checkout.order.id}}",
                    confirmation = $"{baseUrl}OrderConfirm?order_id={{checkout.order.id}}",
                    push = $"{apiUrl}KlarnaOrderPush"
                },
                billing_address = customerAddress
            };

            var checkoutDTOContent = JsonContent.Create(checkoutDTO);
            Console.WriteLine(checkoutDTOContent.ToString());

            var response = await _httpClient.PostAsJsonAsync("/checkout/v3/orders", checkoutDTO);
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning($"Error when sending order request to klarna: {response.ReasonPhrase}");
                return null;
            } else
            {
                var result = await response.Content.ReadAsStringAsync();
                var responseDTO = await response.Content.ReadFromJsonAsync<KlarnaResponseDTO>();
                return responseDTO;
            }
        }

        public async Task<KlarnaOrderDTO> GetOrder(string order_id)
        {
            KlarnaOrderDTO order = new KlarnaOrderDTO();
            var response = await _httpClient.GetAsync($"/checkout/v3/orders/{order_id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadFromJsonAsync<KlarnaOrderDTO>();

            return result;
        }
    }
}

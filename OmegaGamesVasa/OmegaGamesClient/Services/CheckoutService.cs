using System.Net.Http.Headers;
using System.Text;
using Azure;
using Common.DTO;

namespace OmegaGamesAPI.Services;

public class CheckoutService
{
    private readonly HttpClient _httpClient;

    public CheckoutService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("HyggligApi");
    }

    public async Task CheckoutPostAsync(OrderDTO request, string username, string password)
    {
        var newHyggligDTO = new HyggligDTO
        {
            SuccessUrl = "/Home",
            Push_notification_url = "/Home"
        };
        var json = JsonContent.Create(request);
        //var json = JsonConvert.SerializeObject(request);

        //var httpContent = new StringContent(json, Encoding.UTF8,
        //    "application/json");

        string authInfo = $"{username}:{password}";

        string base64Encoded =
            Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(authInfo));

        HttpRequestMessage httpRequestMessage = new
            HttpRequestMessage(HttpMethod.Post, "api/checkout");

        httpRequestMessage.Headers.Authorization = new
            AuthenticationHeaderValue("Basic", base64Encoded);

        httpRequestMessage.Content = json;

        await _httpClient.SendAsync(httpRequestMessage);
    }
}
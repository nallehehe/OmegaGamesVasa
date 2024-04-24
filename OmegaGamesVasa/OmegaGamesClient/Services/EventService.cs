using Common.DTO;
using Common.Interface;

namespace OmegaGamesApi.Services;

public class EventService : IEventService<EventDTO>
{
    private readonly HttpClient _httpClient;

    public EventService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("OmegaGamesAPI");
    }
    public async Task<IEnumerable<EventDTO>> GetAllEvents()
    {
        var response = await _httpClient.GetAsync("events");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<EventDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<EventDTO>>();
        return result ?? Enumerable.Empty<EventDTO>();
    }

    public Task AddEventAsync(EventDTO e)
    {
        throw new NotImplementedException();
    }
}
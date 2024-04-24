using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Events.Get.GetAllEvents;

public class GetAllEventsHandler(IEventService<Event> repo) : Endpoint<EmptyRequest, IEnumerable<Event>>
{

    public override void Configure()
    {
        Get("/events");
        AllowAnonymous();
    }


    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var events = await repo.GetAllEvents();

        SendAsync(events, cancellation: ct);
    }

}
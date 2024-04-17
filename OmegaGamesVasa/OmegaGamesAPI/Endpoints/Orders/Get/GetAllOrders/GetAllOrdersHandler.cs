using Common.DTO;
using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using FastEndpoints;
using Order = DataAccess.Entities.Order;

namespace OmegaGamesAPI.Endpoints.Orders.Get.GetAllOrders;

public class GetAllOrdersHandler(IOrderRepository<Order> repo) : Endpoint<EmptyRequest, IEnumerable<Order>>
{

    public override void Configure()
    {
        Get("/orders");
        AllowAnonymous();
    }


    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var orders = await repo.GetAllOrders();

        SendAsync(orders, cancellation: ct);
    }

}
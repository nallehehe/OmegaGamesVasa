using Common.DTO;
using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Products.Get.GetAllOrders;

public class GetAllOrdersHandler(OrderRepository repo) : Endpoint<EmptyRequest, IEnumerable<OrderDTO>>
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
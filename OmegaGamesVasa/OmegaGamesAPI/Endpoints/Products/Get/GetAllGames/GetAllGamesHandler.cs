using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Products.Get.GetAllGames;

public class GetAllGamesHandler(IProductService<Product> repo) : Endpoint<EmptyRequest, IEnumerable<Product>>
{

    public override void Configure()
    {
        Get("/products/games");
        AllowAnonymous();
    }


    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var products = await repo.GetAllGames();

        SendAsync(products, cancellation: ct);
    }

}
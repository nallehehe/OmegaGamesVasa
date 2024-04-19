using Common.DTO;
using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Products.Post;

public class AddProductsHandler(IProductService<Product> repo) : Endpoint<ProductDTO, EmptyResponse>
{

    public override void Configure()
    {
        Post("/products");
        AllowAnonymous();
    }


    public override async Task HandleAsync(ProductDTO req, CancellationToken ct)
    {
        var newProduct = new Product
        {
            Id = req.Id,
            AgeRestriction = req.AgeRestriction,
            Category = req.Category,
            Description = req.Description,
            Genre = req.Genre,
            Image = req.Image,
            Price = req.Price,
            ProductName = req.ProductName,
            Stock = req.Stock
        };


        await repo.AddProductAsync(newProduct);

        SendAsync(new EmptyResponse(), cancellation: ct);
    }

}
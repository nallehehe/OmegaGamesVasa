using Common.DTO;
using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;
using OmegaGamesAPI.Endpoints.Products.Get.GetAndUseProductCode;
using Order = DataAccess.Entities.Order;

namespace OmegaGamesAPI.Endpoints.Orders.Put.AddCodesToOrder;

public class AddCodesToOrderHandler(IOrderRepository<Order> repo) : Endpoint<OrderDTO, Order>
{

    public override void Configure()
    {
        Put("/orders");
        AllowAnonymous();
    }


    public override async Task HandleAsync(OrderDTO req, CancellationToken ct)
    {
        var newOrder = new Order
        {
            CustomerAddress = req.CustomerAddress,
            CustomerEmail = req.CustomerEmail,
            OrderDate = req.OrderDate,
            CustomerFirstName = req.CustomerFirstName,
            CustomerId = req.CustomerId,
            CustomerLastName = req.CustomerLastName,
            CustomerPhone = req.CustomerPhone
        };

        foreach (var product in req.CustomerCart)
        {
            newOrder.CustomerCart.Add(new ProductInCartDTO()
            {
                AgeRestriction = product.AgeRestriction,
                ProductName = product.ProductName,
                Category = product.Category,
                Description = product.Description,
                Genre = product.Genre,
                Id = product.Id,
                Image = product.Image,
                Price = product.Price, 
                ProductKey = product.ProductKey
            });
            newOrder.TotalPrice += product.Price;
        }

        var addedOrder = await repo.UpdateOrderAsync(newOrder);

        await SendAsync(addedOrder, cancellation: ct);
    }


}
﻿using Common.DTO;
using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;
using Order = DataAccess.Entities.Order;


namespace OmegaGamesAPI.Endpoints.Orders.Post.AddNewOrder;

public class AddOrderHandler(IOrderRepository<Order> repo) : Endpoint<OrderDTO, EmptyResponse>
{

    public override void Configure()
    {
        Post("/orders");
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
            newOrder.CustomerCart.Add(new Product()
            {
                AgeRestriction = product.AgeRestriction,
                ProductName = product.ProductName,
                Category = product.Category,
                Description = product.Description,
                Genre = product.Genre,
                Id = product.Id,
                Image = product.Image,
                Price = product.Price,
                Stock = product.Stock
            });
            newOrder.TotalPrice += product.Price;
        }

        await repo.AddOrderAsync(newOrder);

        SendAsync(new EmptyResponse(), cancellation: ct);
    }

}
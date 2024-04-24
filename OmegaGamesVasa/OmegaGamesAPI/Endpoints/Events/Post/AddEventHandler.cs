﻿using Common.DTO;
using Common.Interface;
using DataAccess.Entities;
using DataAccess.Entities.Codes;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Events.Post;

public class AddEventHandler(IEventService<Event> repo, IProductService<Product> productRepo) : Endpoint<AddEventDTO, EmptyResponse>
{

    public override void Configure()
    {
        Post("/events");
        AllowAnonymous();
    }


    public override async Task HandleAsync(AddEventDTO req, CancellationToken ct)
    {
        var newTicket = new Product()
        {
            AgeRestriction = 0,
            Category = "Event ticket",
            Description = $"Biljett till evenemang: {req.Title}",
            Genre = "Event",
            Image = req.Image,
            ProductName = $"Biljett till evenemang: {req.Title}",
            Stock = 100,
            Codes = new List<ProductCode>(),
            Price = req.Price
        };
        await productRepo.AddProductAsync(newTicket);

        var newEvent = new Event
        {
            Id = req.Id,
            Description = req.Description,
            EndDate = req.EndDate,
            StartDate = req.StartDate,
            Image = req.Image,
            Title = req.Title,
            Ticket = newTicket
        };

        await repo.AddEventAsync(newEvent);

        SendAsync(new EmptyResponse(), cancellation: ct);
    }

}
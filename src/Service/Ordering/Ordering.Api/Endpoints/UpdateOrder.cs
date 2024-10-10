﻿using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.Api.Endpoints;

public record UpdateOrderRequest(OrderDto OrderDto);
public record UpdateOrderResponse(bool IsSuccess);
public class UpdateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            var req = request.Adapt<UpdateOrderRequest>();
            var result = await sender.Send(req);
            var response = result.Adapt<UpdateOrderResponse>();
            return Results.Ok(response);
        })
        .WithName("UpdateOrder")
        .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Order")
        .WithDescription("Update Order"); ;
    }
}

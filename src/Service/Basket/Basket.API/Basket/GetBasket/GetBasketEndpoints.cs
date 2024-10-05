
namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string UserName) : ICommand<GetBasketResponse>;
public record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var response = await sender.Send(new GetBasketQuery(userName));
            var result = response.Adapt<GetBasketResponse>();

            return Results.Ok(result);
        })
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basket")
        .WithDescription("Get Basket");
    }
}

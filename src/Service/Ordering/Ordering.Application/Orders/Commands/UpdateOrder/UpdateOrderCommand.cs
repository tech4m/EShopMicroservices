using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto OrderDto) : ICommand<UpdateOrderResponse>;
public record UpdateOrderResponse(bool IsSuccess);

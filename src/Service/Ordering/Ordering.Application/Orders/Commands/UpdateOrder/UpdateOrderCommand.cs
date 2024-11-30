namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResponse>;
public record UpdateOrderResponse(bool IsSuccess);

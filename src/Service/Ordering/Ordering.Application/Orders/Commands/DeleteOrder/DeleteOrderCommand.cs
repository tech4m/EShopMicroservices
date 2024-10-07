namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid Id);
public record DeleteOrderResult(bool IsSuccess);

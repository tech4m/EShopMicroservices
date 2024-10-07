namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId);
public record GetOrdersByCustomerResult(IEnumerable<OrderDto> OrderDtos);

using Ordering.Domain.Abstractions;
using Ordering.Domain.Models;

namespace Ordering.Domain.Orders.Events;
public record OrderCreatedEvent(Order order) : IDomainEvent;
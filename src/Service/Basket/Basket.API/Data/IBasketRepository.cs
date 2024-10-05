﻿namespace Basket.API.Data;

public interface IBasketRepository
{
    public Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
    public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken);
    public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
}

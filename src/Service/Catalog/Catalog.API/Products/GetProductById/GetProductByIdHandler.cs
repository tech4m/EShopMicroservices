﻿namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid id):IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);
public class GetProductByIdHandler(IDocumentSession session)
{
}

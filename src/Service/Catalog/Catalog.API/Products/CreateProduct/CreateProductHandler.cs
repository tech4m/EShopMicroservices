using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand
    (
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
    ) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class CreateProductHandler (IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Business logic will come here
        //Save to database
        //and RETURN CraeteProductResult
        var product = new Product
        {
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Name = command.Name,
            Price = command.Price
        };
        //To Do
        //save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(Guid.NewGuid());
    }
}

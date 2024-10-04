namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid id):ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);
public class DeleteProductHandler(IDocumentSession session)
{
}

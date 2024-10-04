namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category);
public record GetProductByCategoryResult(IEnumerable<Product> Products);
public class GetProductByCategoryHandler(IDocumentSession session)
{
}

using InternetShop.UseCases.Commands.Product.PostProduct;
using InternetShop.UseCases.Commands.Product.PutProduct;

namespace InternetShop.UseCases.Interfaces.Products;
public interface IProductService
{
    Task PostAddProductAsync(PostProductCommand request, CancellationToken cancellationToken);
    Task PutUpdateProductInfoAsync(Guid id, PutProductCommand request, CancellationToken cancellationToken);
}

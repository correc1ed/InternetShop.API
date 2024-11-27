using InternetShop.UseCases.DTOs.Products.Requests.PostProduct;
using InternetShop.UseCases.DTOs.Products.Requests.PutProduct;

namespace InternetShop.UseCases.Interfaces.Products;
public interface IProductService
{
    Task PostAddProductAsync(PostProductRequest request, CancellationToken cancellationToken);
    Task PutUpdateProductInfoAsync(Guid id, PutProductRequest request, CancellationToken cancellationToken);
}

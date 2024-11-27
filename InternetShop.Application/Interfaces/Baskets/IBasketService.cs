using InternetShop.UseCases.DTOs.Baskets.Requests.PostAddProductToBasketById;

namespace InternetShop.UseCases.Interfaces.Baskets;
public interface IBasketService
{
    Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken);
    Task DeleteProductByIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
}


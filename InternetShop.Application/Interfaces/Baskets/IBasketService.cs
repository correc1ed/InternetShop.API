using InternetShop.UseCases.Commands.Basket.PostAddProductToBasketById;

namespace InternetShop.UseCases.Interfaces.Baskets;
public interface IBasketService
{
    Task AddProductAsync(PostAddProductToBasketByIdCommand request, CancellationToken cancellationToken);
    Task DeleteProductByIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
}


using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces.Repository;
public interface IBasketRepository : IBaseRepository<Basket>
{
    Task<Basket?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task SaveAsync(Basket basket, CancellationToken cancellationToken);
    Task DeleteAsync(Guid basketId, CancellationToken cancellationToken);
    Task RemoveProduct(Guid productId, Guid userId);
}

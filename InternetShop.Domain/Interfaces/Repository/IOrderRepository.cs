using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces.Repository;
public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<Order> GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken);
}

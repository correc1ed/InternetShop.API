using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    public Task<IEnumerable<Order>> GetOrderListAsync(Guid userId, CancellationToken cancellationToken);
}

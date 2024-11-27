using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Persistence.Repository;
public class UserRepository : IUserRepository
{
    private readonly EfContext _dbContext;
    public UserRepository(
        EfContext db)
    {
        _dbContext = db;
    }
    public async Task<List<Order>> GetOrderListAsync(Guid userId, CancellationToken cancellationToken)
    {
        if (userId == null)
        {
            throw new Exception("Запрос пустой.");
        }
        var orders = _dbContext.Orders
            .Include(u => u.User)
            .Include(p => p.Products)
            .Where(o => o.User.Id == userId).ToList();

        if (orders == null || orders.Count == 0)
        {
            throw new Exception("У пользователя с данным идентификатором отсутствуют заказы");
        }

        return orders;
    }

    public DbSet<User> Entities => throw new NotImplementedException();

    public async Task AddAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var result = await _dbContext.Users
            .ToListAsync();

        return result;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        return result;
    }

    public async Task RemoveAsync(User entity)
    {
        _dbContext.Users.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}

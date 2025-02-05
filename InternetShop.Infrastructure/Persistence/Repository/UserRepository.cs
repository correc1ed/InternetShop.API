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
    public async Task<IEnumerable<Order>> GetOrderListAsync(Guid userId, CancellationToken cancellationToken)
    {
        if (userId == Guid.Empty)
        {
			throw new ArgumentException("Идентификатор пользователя не может быть пустым.", nameof(userId));
		}
        var orders = await _dbContext.Orders
            .Include(u => u.User)
            .Where(o => o.User.Id == userId).ToListAsync();

        if (orders == null || orders.Count == 0)
        {
			throw new KeyNotFoundException($"Заказы для пользователя с идентификатором {userId} не найдены.");
		}

        return orders;
    }

    public async Task AddAsync(User entity)
	{
		if (entity == null)
		{
			throw new ArgumentException("Добавляемая сущность не может быть пустой.", nameof(entity));
		}
		await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var result = await _dbContext.Users
            .ToListAsync();

		if (result == null)
		{
			throw new ArgumentException("Список пользователей в бд пуст.", nameof(result));
		}

		return result;
    }

    public async Task<User?> GetByIdAsync(Guid id)
	{
		if (id == Guid.Empty)
		{
			throw new ArgumentException("Идентификатор пользователя не может быть пустым.", nameof(id));
		}
		var result = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        return result;
    }

    public async Task RemoveAsync(User entity)
	{
		if (entity == null)
		{
			throw new ArgumentException("Удаляемая сущность не может быть пустой.", nameof(entity));
		}

		_dbContext.Users.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
	{
		if (entity == null)
		{
			throw new ArgumentException("Обновляемая сущность не может быть пустой.", nameof(entity));
		}

		_dbContext.Users.Update(entity);

        await _dbContext.SaveChangesAsync();
    }
}

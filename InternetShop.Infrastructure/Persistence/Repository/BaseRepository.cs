using InternetShop.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Persistence.Repository;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	protected readonly EfContext _context;

	public BaseRepository(EfContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		return await _context.Set<TEntity>().ToListAsync();
	}

	public async Task<TEntity?> GetByIdAsync(Guid id)
	{
		return await _context.Set<TEntity>().FindAsync(id);
	}

	public async Task AddAsync(TEntity entity)
	{
		await _context.Set<TEntity>().AddAsync(entity);
		await SaveChangesAsync();
	}

	public async Task UpdateAsync(TEntity entity)
	{
		_context.Set<TEntity>().Update(entity);
		await SaveChangesAsync();
	}

	public async Task RemoveAsync(TEntity entity)
	{
		_context.Set<TEntity>().Remove(entity);
		await SaveChangesAsync();
	}

	protected async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}
}

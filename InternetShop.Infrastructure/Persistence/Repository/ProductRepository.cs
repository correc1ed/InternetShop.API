using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Persistence.Repository;
public class ProductRepository : IProductRepository
{
    private readonly EfContext _dbContext;
    public ProductRepository(
        EfContext db)
    {
        _dbContext = db;
    }

    public async Task AddAsync(Product entity)
	{
		if (entity == null)
		{
			throw new ArgumentException("Добавляемая сущность не может быть пустой.", nameof(entity));
		}

		await _dbContext.Products.AddAsync(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var result = await _dbContext.Products.ToListAsync();

		if (result == null)
		{
			throw new ArgumentException("Список товаров в бд пуст.", nameof(result));
		}

		return result;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
		if (id == Guid.Empty)
		{
			throw new ArgumentException("Идентификатор товара не может быть пустым.", nameof(id));
		}

		var result = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task RemoveAsync(Product entity)
	{
		if (entity == null)
		{
			throw new ArgumentException("Удаляемая сущность не может быть пустой.", nameof(entity));
		}

		_dbContext.Products.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
	{
		if (entity == null)
		{
			throw new ArgumentException("Обновляемая сущность не может быть пустой.", nameof(entity));
		}

		_dbContext.Products.Update(entity);

        await _dbContext.SaveChangesAsync();
    }
}

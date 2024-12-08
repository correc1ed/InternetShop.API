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
    public DbSet<Product> Entities => throw new NotImplementedException();

    public async Task AddAsync(Product entity)
    {
        await _dbContext.Products.AddAsync(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var result = await _dbContext.Products.ToListAsync();

        return result;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task RemoveAsync(Product entity)
    {
        _dbContext.Products.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);

        await _dbContext.SaveChangesAsync();
    }
}

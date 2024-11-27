﻿using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Persistence.Repository;
public class BasketRepository : IBasketRepository
{
    private readonly EfContext _dbContext;

    public DbSet<Basket> Entities => throw new NotImplementedException();

    public BasketRepository(EfContext context)
    {
        _dbContext = context;
    }

    public async Task DeleteAsync(Guid basketId, CancellationToken cancellationToken)
    {
        var basketEntity = await _dbContext.Baskets
            .FirstOrDefaultAsync(b => b.Id == basketId, cancellationToken);

        if (basketEntity is not null)
        {
            _dbContext.Baskets.Remove(basketEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    async Task<Basket?> IBasketRepository.GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var basket = await _dbContext.Baskets
            .Include(u => u.User)
            .Include(b => b.Products)
            .FirstOrDefaultAsync(b => b.User.Id == userId, cancellationToken);

        return basket is null ? null : basket;
    }

    public async Task SaveAsync(Basket basket, CancellationToken cancellationToken)
    {
        var basketEntity = await _dbContext.Baskets
            .FirstOrDefaultAsync(b => b.Id == basket.Id, cancellationToken);

        if (basketEntity is null)
        {
            basketEntity = basket;
            await _dbContext.Baskets.AddAsync(basketEntity, cancellationToken);
        }
        else
        {
            _dbContext.Entry(basketEntity).CurrentValues.SetValues(basket);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task RemoveProduct(Guid productId, Guid userId)
    {
        var basket = await _dbContext.Baskets
            .Include(p => p.Products)
            .FirstOrDefaultAsync(b => b.User.Id == userId);

        if (basket is null)
            throw new ArgumentNullException(nameof(basket));

        var product = await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
            throw new ArgumentNullException(nameof(product));

        basket.Products.Remove(product);

        await _dbContext.SaveChangesAsync();
    }
    public Task UpdateAsync(Basket entity)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Basket>> GetAllAsync()
    {
        var result = await _dbContext.Baskets.ToListAsync();

        return result;
    }

    public async Task AddAsync(Basket entity)
    {
        await _dbContext.Baskets.AddAsync(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Basket entity)
    {
        _dbContext.Baskets.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Basket?> GetByIdAsync(Guid id)
    {
        var basket = await _dbContext.Baskets
            .FirstOrDefaultAsync(b => b.Id == id);

        return basket;
    }
}

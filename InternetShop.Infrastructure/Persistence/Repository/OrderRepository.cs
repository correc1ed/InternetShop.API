using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.DTOs.Orders.Responses.GetOrderInformationById;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Persistence.Repository;
public class OrderRepository : IOrderRepository
{
    private readonly EfContext _dbContext;
    public OrderRepository(
        EfContext db)
    {
        _dbContext = db;
    }

    public DbSet<Order> Entities => throw new NotImplementedException();

    public async Task AddAsync(Order entity)
    {
        await _dbContext.Orders.AddAsync(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var results = await _dbContext.Orders
            .ToListAsync();

        return results;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Orders
            .FirstOrDefaultAsync(o => o.Id == id);

        return result;
    }

    public async Task<Order> GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        /*
         * (id есть, данные в бд есть — а в переменную ничерта не записывается) Наверное очередная глупая ошибка которую я упустил
         * */
        var order = await _dbContext.Orders // вот тут неведомая ошибка.
                .Include(x => x.User)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(o => o.Id == id)
            ;

        if (order == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        if (order.User == null)
        {
            throw new Exception("Данный заказ не имеет пользователя.");
        }

        if (order.Products == null)
        {
            throw new Exception("Данный заказ не имеет продуктов");
        }

        return order;
    }

    public async Task RemoveAsync(Order entity)
    {
        _dbContext.Orders.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }
}

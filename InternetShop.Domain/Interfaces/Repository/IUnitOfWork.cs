namespace InternetShop.Domain.Interfaces.Repository;
public interface IUnitOfWork
{
    IBaseRepository<T> Repository<T>() where T : class;
    Task SaveChangesAsync();
}

using InternetShop.UseCases.Commands.Order.PostOrder;
using InternetShop.UseCases.Commands.Order.PutOrderStatus;

namespace InternetShop.UseCases.Interfaces.Orders;
public interface IOrderService
{
    Task AddOrderAsync(PostOrderCommand request, CancellationToken cancellationToken);
    Task PutUpdateOrderStatusAsync(Guid orderId, PutOrderStatusCommand request, CancellationToken cancellationToken);
}

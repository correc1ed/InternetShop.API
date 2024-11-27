using InternetShop.UseCases.DTOs.Orders;
using InternetShop.UseCases.DTOs.Orders.Requests.PostOrder;
using InternetShop.UseCases.DTOs.Orders.Requests.PutOrderStatus;

namespace InternetShop.UseCases.Interfaces.Orders;
public interface IOrderService
{
    OrderDTO GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken);
    Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken);
}

using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.DTOs.Orders;
using InternetShop.UseCases.DTOs.Orders.Requests.PostOrder;
using InternetShop.UseCases.DTOs.Orders.Requests.PutOrderStatus;
using InternetShop.UseCases.Interfaces.Orders;

namespace InternetShop.Infrastructure.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(
        IOrderRepository orderRepository
    )
    {
        _orderRepository = orderRepository;
    }
    public async Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = Order.Create(
            request.User,
            request.Products,
            request.Status,
            request.CreatedAt,
            request.DeliveredDate);

        await _orderRepository.AddAsync(order);
    }

    public async Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = _orderRepository.GetByIdAsync(orderId).Result;

        if (order == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        await _orderRepository.RemoveAsync(order);

        order.Status = request.Status;

        await _orderRepository.AddAsync(order);
    }

    OrderDTO IOrderService.GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

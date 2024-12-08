using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.Commands.Order.PostOrder;
using InternetShop.UseCases.Commands.Order.PutOrderStatus;
using InternetShop.UseCases.Interfaces.Orders;

namespace InternetShop.Infrastructure.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    public OrderService(
        IOrderRepository orderRepository,
        IUserRepository userRepository
    )
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }
    public async Task AddOrderAsync(PostOrderCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = await _userRepository.GetByIdAsync(request.User);

        if (user is null)
            throw new ArgumentNullException(nameof(user));

        var order = Order.Create(
            user,
            request.Products,
            request.Status,
            request.CreatedAt,
            request.DeliveredDate);

        await _orderRepository.AddAsync(order);
    }

    public async Task PutUpdateOrderStatusAsync(Guid orderId, PutOrderStatusCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = _orderRepository.GetByIdAsync(orderId).Result;

        if (order == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        order.Status = request.Status;

        await _orderRepository.UpdateAsync(order);
    }
}

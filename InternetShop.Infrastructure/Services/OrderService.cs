using InternetShop.Domain.Entities;
using InternetShop.Domain.Entities.Enums;
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

		if (!Enum.IsDefined(typeof(Status), request.Status))
		{
			throw new ArgumentException("Некорректный статус заказа.", nameof(request.Status));
		}

		if (request.CreatedAt == default)
		{
			throw new ArgumentException("Дата создания заказа должна быть указана.", nameof(request.CreatedAt));
		}

		if (request.DeliveredDate == default)
		{
			throw new ArgumentException("Дата доставки заказа должна быть указана.", nameof(request.DeliveredDate));
		}

		if (request.DeliveredDate < request.CreatedAt)
		{
			throw new ArgumentException("Дата доставки не может быть раньше даты создания заказа.", nameof(request.DeliveredDate));
		}
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

		if (!Enum.IsDefined(typeof(Status), request.Status))
		{
			throw new ArgumentException("Некорректный статус заказа.", nameof(request.Status));
		}

		order.Status = request.Status;

		await _orderRepository.UpdateAsync(order);
	}
}

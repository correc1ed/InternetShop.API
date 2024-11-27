using InternetShop.UseCases.Interfaces.Orders;
using MediatR;

namespace InternetShop.UseCases.Commands.Order.PostOrder;

public class PostOrderCommandHandler : IRequestHandler<PostOrderCommand>
{
    private readonly IOrderService _orderService;

    public PostOrderCommandHandler(
        IOrderService orderService
    )
    {
        _orderService = orderService;
    }
    async Task IRequestHandler<PostOrderCommand>.Handle(PostOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderService.AddOrderAsync(request, cancellationToken);
    }
}

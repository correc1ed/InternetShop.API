using InternetShop.UseCases.Interfaces.Orders;
using MediatR;

namespace InternetShop.UseCases.Commands.Order.PutOrderStatus;

public class PutOrderStatusCommandHandler : IRequestHandler<PutOrderStatusCommand>
{
    private readonly IOrderService _orderService;

    public PutOrderStatusCommandHandler(
        IOrderService orderService
    )
    {
        _orderService = orderService;
    }
    async Task IRequestHandler<PutOrderStatusCommand>.Handle(PutOrderStatusCommand request, CancellationToken cancellationToken)
    {
        await _orderService.PutUpdateOrderStatusAsync(request.Id, request, cancellationToken);
    }
}
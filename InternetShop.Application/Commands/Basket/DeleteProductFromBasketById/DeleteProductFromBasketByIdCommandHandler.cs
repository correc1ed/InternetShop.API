using InternetShop.UseCases.Interfaces.Baskets;
using MediatR;

namespace InternetShop.UseCases.Commands.Basket.DeleteProductFromBasketById;

/// <summary>
/// Обработчик <see cref="DeleteProductFromBasketByIdCommand"/>
/// </summary>
/// 
public class DeleteProductFromBasketByIdCommandHandler : IRequestHandler<DeleteProductFromBasketByIdCommand>
{
    private readonly IBasketService _basketService;

    public DeleteProductFromBasketByIdCommandHandler(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    public async Task Handle(DeleteProductFromBasketByIdCommand request, CancellationToken cancellationToken)
    {
        await _basketService.DeleteProductByIdAsync(request.Id, request.ProductId, cancellationToken).ConfigureAwait(false);
    }
}

using InternetShop.UseCases.Interfaces.Baskets;
using MediatR;

namespace InternetShop.UseCases.Commands.Basket.PostAddProductToBasketById;

public class PostAddProductToBasketByIdCommandHandler : IRequestHandler<PostAddProductToBasketByIdCommand>
{
    private readonly IBasketService _basketService;

    public PostAddProductToBasketByIdCommandHandler(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    async Task IRequestHandler<PostAddProductToBasketByIdCommand>.Handle(PostAddProductToBasketByIdCommand request, CancellationToken cancellationToken)
    {
        await _basketService.AddProductAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
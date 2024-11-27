using InternetShop.UseCases.Interfaces.Products;
using MediatR;

namespace InternetShop.UseCases.Commands.Product.PutProduct;

public class PutProductCommandHandler : IRequestHandler<PutProductCommand>
{
    private readonly IProductService _productService;

    public PutProductCommandHandler(
        IProductService productService
    )
    {
        _productService = productService;
    }
    async Task IRequestHandler<PutProductCommand>.Handle(PutProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.PutUpdateProductInfoAsync(request.Id, request, cancellationToken);
    }
}

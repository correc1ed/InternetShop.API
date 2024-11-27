using InternetShop.UseCases.Interfaces.Products;
using MediatR;

namespace InternetShop.UseCases.Commands.Product.PostProduct;

public class PostProductCommandHandler : IRequestHandler<PostProductCommand>
{
    private readonly IProductService _productService;

    public PostProductCommandHandler(
        IProductService productService
    )
    {
        _productService = productService;
    }
    async Task IRequestHandler<PostProductCommand>.Handle(PostProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.PostAddProductAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
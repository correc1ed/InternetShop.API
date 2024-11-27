using InternetShop.UseCases.Commands.Basket.DeleteProductFromBasketById;
using InternetShop.UseCases.Commands.Basket.PostAddProductToBasketById;
using InternetShop.UseCases.DTOs.Baskets.Requests.DeleteProductFromBasketById;
using InternetShop.UseCases.DTOs.Baskets.Requests.PostAddProductToBasketById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers;
[ApiController]
[Route("[controller]")]
public class BasketController : ApiControllerBase
{
    /// <summary>
    /// Добавление товара в корзину
    /// </summary>
    [HttpPost("/addProduct")]
    public async Task AddProduct(
            [FromServices] IMediator mediator,
            [FromBody] PostAddProductToBasketByIdRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostAddProductToBasketByIdCommand(request), cancellationToken);
    }

    /// <summary>
    /// Удаление товара из корзины
    /// </summary>
    [HttpDelete("/deleteProduct/{id}")]
    public async Task DeleteProductById(
            [FromServices] IMediator mediator,
            [FromBody] DeleteProductFromBasketByIdRequest request,
            [FromQuery] Guid id,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteProductFromBasketByIdCommand(id, request), cancellationToken);
    }
}

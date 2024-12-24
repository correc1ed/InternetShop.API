using InternetShop.UseCases.Commands.Product.PostProduct;
using InternetShop.UseCases.Commands.Product.PutProduct;
using InternetShop.UseCases.DTOs.Products.Requests.PostProduct;
using InternetShop.UseCases.DTOs.Products.Requests.PutProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ApiControllerBase
{
    /// <summary>
    /// Добавление товара
    /// </summary>
    [Authorize(Policy = "AdminPolicy")]
    [HttpPost]
    public async Task Add(
        [FromServices] IMediator mediator,
        [FromBody] PostProductRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new PostProductCommand(request), cancellationToken);
    }

    /// <summary>
    /// Обновление информации о товаре
    /// </summary>
    [Authorize(Policy = "AdminPolicy")]
    [HttpPut]
    public async Task UpdateInfoById(
        [FromServices] IMediator mediator,
        [FromQuery] Guid id,
        [FromBody] PutProductRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new PutProductCommand(id, request), cancellationToken);
    }
}

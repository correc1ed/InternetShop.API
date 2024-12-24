using InternetShop.UseCases.Commands.Order.PostOrder;
using InternetShop.UseCases.Commands.Order.PutOrderStatus;
using InternetShop.UseCases.DTOs.Orders.Requests.PostOrder;
using InternetShop.UseCases.DTOs.Orders.Requests.PutOrderStatus;
using InternetShop.UseCases.DTOs.Orders.Responses.GetOrderInformationById;
using InternetShop.UseCases.Queries.Order.GetOrderInformation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ApiControllerBase
{
    /// <summary>
    /// Получение деталей заказа
    /// </summary>
    //[Authorize(Policy = "UserPolicy")]
    [HttpGet]
    public async Task<GetOrderInfoByIdResponse> GetById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            CancellationToken cancellationToken) => await mediator.Send(new GetOrderInformationQuery(id), cancellationToken);

    /// <summary>
    /// Создание заказа
    /// </summary>
    //[Authorize(Policy = "UserPolicy")]
    [HttpPost]
    public async Task AddOrder(
            [FromServices] IMediator mediator,
            [FromBody] PostOrderRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostOrderCommand(request), cancellationToken);
    }

    /// <summary>
    /// Изменение статуса заказа
    /// </summary>
    //[Authorize(Policy = "UserPolicy")]
    [HttpPut]
    public async Task UpdateOrderStatusById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUpdateOrderStatusRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutOrderStatusCommand(id, request), cancellationToken);
    }
}

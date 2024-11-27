using InternetShop.UseCases.Commands.User.PostUserLogin;
using InternetShop.UseCases.Commands.User.PostUserRegistration;
using InternetShop.UseCases.Commands.User.PutUserProfile;
using InternetShop.UseCases.Commands.User.PutUserProfileForAdmin;
using InternetShop.UseCases.DTOs.Users.Requests.PostUserLogin;
using InternetShop.UseCases.DTOs.Users.Requests.PostUserRegistration;
using InternetShop.UseCases.DTOs.Users.Requests.PutUserProfile;
using InternetShop.UseCases.DTOs.Users.Requests.PutUserProfileForAdmin;
using InternetShop.UseCases.DTOs.Users.Responses.GetOrderList;
using InternetShop.UseCases.Queries.User.GetUserOrderList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ApiControllerBase
{
    /// <summary>
    /// Получение списка заказов пользователя
    /// </summary>
    [HttpGet("{id}")]
    //[Authorize]
    public async Task<GetUserOrderListResponse> GetById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            CancellationToken cancellationToken) => await mediator.Send(new GetUserOrderListQuery(id), cancellationToken);

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>
    [HttpPost("auth/")]
    //[Authorize]
    public async Task Authorization(
            [FromServices] IMediator mediator,
            [FromBody] PostUserLoginRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostUserLoginCommand(request), cancellationToken);
    }

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>.
    [HttpPost("register/")]
    //[Authorize]
    public async Task Register(
            [FromServices] IMediator mediator,
            [FromBody] PostUserRegistrationRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostUserRegistrationCommand(request), cancellationToken);
    }

    /// <summary>
    /// Обновление профиля
    /// </summary>
    [HttpPut("forUser/{id}")]
    //[Authorize]
    public async Task UpdateUserById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUserProfileRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutUserProfileCommand(id, request), cancellationToken);
    }

    /// <summary>
    /// Обновление профиля от имени администратора
    /// </summary>
    [HttpPut("forAdmin/{id}")]
    //[Authorize]
    public async Task UpdateUserForAdminById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUserProfileForAdminRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutUserProfileForAdminCommand(id, request), cancellationToken);
    }
}

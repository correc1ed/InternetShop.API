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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternetShop.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ApiControllerBase
{
    /// <summary>
    /// Получение списка заказов пользователя
    /// </summary>
    [Authorize(Policy = "AdminPolicy")]
    [HttpGet]
    public async Task<GetUserOrderListResponse> GetById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            CancellationToken cancellationToken) => await mediator.Send(new GetUserOrderListQuery(id), cancellationToken);

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>
    [HttpPost("auth")]
    public async Task<IActionResult> Authorization(
            [FromServices] IMediator mediator,
            [FromBody] PostUserLoginRequest request,
            CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new PostUserLoginCommand(request), cancellationToken);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, response.Id.ToString()),
            new Claim(ClaimTypes.Email, response.Email),
            new Claim(ClaimTypes.Role, response.IsAdministrator.ToString().ToLower())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        HttpContext.User = principal;

        var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

        return Ok(new
        {
            Authenticated = isAuthenticated
        });
    }

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>.
    [HttpPost("register/")]
    public async Task Register(
            [FromServices] IMediator mediator,
            [FromBody] PostUserRegistrationRequest request,
            CancellationToken cancellationToken)
    {
        var value = HttpContext.User.Identity.IsAuthenticated; // тут мы выявили, что оно нам просто никак не аутентифицирует.
        await mediator.Send(new PostUserRegistrationCommand(request), cancellationToken);
    }

    /// <summary>
    /// Обновление профиля
    /// </summary>
    [Authorize(Policy = "UserPolicy")]
    [HttpPut("forUser/")]
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
    [Authorize(Policy = "AdminPolicy")]
    [HttpPut("forAdmin/")]
    public async Task UpdateUserForAdminById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUserProfileForAdminRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutUserProfileForAdminCommand(id, request), cancellationToken);
    }
}

using InternetShop.UseCases.DTOs.Users.Requests.PostUserRegistration;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PostUserRegistration;

/// <summary>
/// Команда запроса <see cref="PostUserRegistrationRequest"/>
/// </summary>
public class PostUserRegistrationCommand : PostUserRegistrationRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserRegistrationCommand(PostUserRegistrationRequest request)
            : base(request) { }
}

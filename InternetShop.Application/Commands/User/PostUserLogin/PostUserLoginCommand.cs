using InternetShop.UseCases.DTOs.Users;
using InternetShop.UseCases.DTOs.Users.Requests.PostUserLogin;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PostUserLogin;
public class PostUserLoginCommand : PostUserLoginRequest, IRequest<UserDTO>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserLoginCommand(PostUserLoginRequest request)
            : base(request) { }
}
